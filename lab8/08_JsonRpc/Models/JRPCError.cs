namespace _08_JsonRpc.Models
{
    public class JrpcError
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public JrpcError()
        {
            Code = (int)ErrorCode.ServerError;
            Message = "Server error";
        }

        public JrpcError(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}