namespace _08_JsonRpc.Models
{
    public class JsonRpcRequest
    {
        public string? Id { get; set; }
        public string? Jsonrpc { get; set; }
        public string? Method { get; set; }
        public ParamsData? Parameters { get; set; }
    }
}