namespace _08_JsonRpc.Models
{
    public class JsonRpcResponce
    {
        public string? Id { get; set; }
        public string Jsonrpc { get; set; }
        
        public int? Result { get; set; }
        
        public JrpcError? Error { get; set; }
    }
}