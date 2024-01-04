namespace _08_JsonRpc.Models;

public enum ErrorCode
{
    InvalidJson = -32700,
    InvalidRequest = -32600,
    MethodNotFound = -32601,
    InvalidParams = -32602,
    InternalError = -32603,
    ServerError = -32000,
    ErrorExit = -32001
}