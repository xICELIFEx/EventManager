using System.Net;

namespace EventManager.Responce;

public class ApiResult<T> : ApiBaseResult
{
    public required T Data { get; set; }
}

public class ApiResult : ApiBaseResult { }

public class ApiBaseResult
{
    public required HttpStatusCode StatusCode { get; set; }
    public required string Message { get; set; }
} 