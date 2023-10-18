using lab3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace lab3.Exceptions
{
    public class ApiExceptionAttribute : ExceptionFilterAttribute
    {
        private string URI = "http://localhost:56665/";
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exception = actionExecutedContext.Exception;

            if (!(exception is BaseException))
            {
                actionExecutedContext.Response = new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.InternalServerError,
                    Content = new StringContent(
                        JsonConvert.SerializeObject(new
                        {
                            StatusCode = System.Net.HttpStatusCode.InternalServerError,
                            SubCode = -1,
                            Description = "Internal server error"
                        }),
                        Encoding.UTF8,
                        "application/json"
                    )
                };
            };

            var baseException = (BaseException)exception;

            var links = new[]
            {
              new Link("self", $"GET {URI}api/errors/{(int)BaseException.StatusCode}/{baseException.SubCode}", "Link to self"),
                new Link("all", $"GET {URI}api/errors", "Link to all errors"),
            };

            actionExecutedContext.Response = new HttpResponseMessage()
            {
                StatusCode = BaseException.StatusCode,
                Content = new StringContent(
                    JsonConvert.SerializeObject(new
                    {
                        BaseException.StatusCode,
                        baseException.SubCode,
                        baseException.Description,
                        links
                    }),
                    Encoding.UTF8,
                    "application/json"
                )
            };
        }
    }
}