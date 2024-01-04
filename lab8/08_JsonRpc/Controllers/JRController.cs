using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using _08_JsonRpc.Models;

namespace _08_JsonRpc.Controllers
{
    [RoutePrefix("api/jrpc")]
    [DisableCors]
    public class JrController : ApiController
    {
        private bool ErrorExitActivated { get; set; }

        [HttpPost]
        [Route("multi")]
        public JsonRpcResponce[]? GetRequests([FromBody] JsonRpcRequest[]? requests)
        {
            return requests?
                .TakeWhile(_ => !ErrorExitActivated)
                .Select(ProcessRequest)
                .ToArray();
        }

        [HttpPost]
        [Route("single")]
        public JsonRpcResponce GetRequest([FromBody] JsonRpcRequest request)
        {
            return ProcessRequest(request);
        }

        private static JsonRpcResponce? ValidateRequest(JsonRpcRequest request)
        {
            var method = request.Method;
            var parameters = request.Parameters;
            var jsonRpc = request.Jsonrpc;
            var id = request.Id;

            if (id is null)
            {
                return new JsonRpcResponce
                {
                    Id = null,
                    Jsonrpc = "2.0",
                    Error = new JrpcError
                    { 
                     Code = (int)ErrorCode.InvalidRequest,
                     Message = "Id is not provided"
                    }
                };
            }
            
            if (jsonRpc is null)
            {
                return new JsonRpcResponce
                {
                    Id = null,
                    Jsonrpc = "2.0",
                    Error = new JrpcError
                    { 
                        Code = (int)ErrorCode.InvalidRequest,
                        Message = "Jsonrpc is not provided"
                    }
                };
            }
            var methods = new[]
            {
                "SetM",
                "GetM",
                "AddM",
                "SubM",
                "MulM",
                "DivM",
                "ErrorExit"
            };
            
            if (method is null || methods.All(m => m != method))
            {
                return new JsonRpcResponce
                {
                    Id = null,
                    Jsonrpc = "2.0",
                    Error = new JrpcError
                    { 
                        Code = (int)ErrorCode.MethodNotFound,
                        Message = "Method is not found"
                    }
                };
            }
            
            var parametersAreNullAndMethodIsNotErrorExit = method != "ErrorExit" && parameters is null;
            
            var noKParameterAndMethodIsNotErrorExit = method != "ErrorExit" && string.IsNullOrEmpty(parameters!.k);
            
            var noNParameterAndMethodIsNotErrorExitOrNotGetM = method is not ("ErrorExit" or "GetM") && parameters!.n is null;

            if (parametersAreNullAndMethodIsNotErrorExit || noKParameterAndMethodIsNotErrorExit || noNParameterAndMethodIsNotErrorExitOrNotGetM)
            {
                return new JsonRpcResponce
                {
                    Id = null,
                    Jsonrpc = "2.0",
                    Error = new JrpcError
                    { 
                        Code = (int)ErrorCode.InvalidParams,
                        Message = "Invalid params"
                    }
                };
            }
            
            return null;
        }
        
        private JsonRpcResponce ProcessRequest(JsonRpcRequest request)
        {
            var validationResponse = ValidateRequest(request);
            if (validationResponse != null)
            {
                return validationResponse;
            }

            var method = request.Method;
            var parameters = request.Parameters;
            var jsonRpc = request.Jsonrpc;

            if (method == "ErrorExit")
            {
                ErrorExit();
                return new JsonRpcResponce
                {
                    Id = request.Id!,
                    Jsonrpc = jsonRpc!,
                    Result = null,
                    Error = new JrpcError((int)ErrorCode.ErrorExit, "ErrorExit activated")
                };
            }

            var k = parameters!.k;
            var n = parameters.n;

            var result = method switch
            {
                "SetM" => SetM(k, (int)n!),
                "GetM" => GetM(k),
                "AddM" => AddM(k, (int)n!),
                "SubM" => SubM(k, (int)n!),
                "MulM" => MulM(k, (int)n!),
                "DivM" => DivM(k, (int)n!),
                _ => null
            };
            
            return new JsonRpcResponce
            {
                Id = request.Id!,
                Jsonrpc = jsonRpc!,
                Result = result
            };
        }

        private int? SetM(string k, int x)
        {
            HttpContext.Current.Session[k] = x;
            return GetM(k);
        }

        private int? GetM(string k)
        {
            var result = HttpContext.Current.Session[k];

            return (int?)result;
        }

        private int? AddM(string k, int x)
        {
            var value = GetM(k);
            HttpContext.Current.Session[k] = value + x;
            return GetM(k);
        }

        private int? SubM(string k, int x)
        {
            var value = GetM(k);
            HttpContext.Current.Session[k] = value - x;
            return GetM(k);
        }

        private int? MulM(string k, int x)
        {
            var value = GetM(k);
            HttpContext.Current.Session[k] = value * x;
            return GetM(k);
        }

        private int? DivM(string k, int x)
        {
            var value = GetM(k);
            HttpContext.Current.Session[k] = value / x;
            return GetM(k);
        }

        private void ErrorExit()
        {
            HttpContext.Current.Session.Clear();
            ErrorExitActivated = true;
        }
    }
}