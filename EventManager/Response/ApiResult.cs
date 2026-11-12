namespace EventManager.Response;

/// <summary>
/// Класс результата с данными полученными в результате выполнения запроса
/// </summary>
public class ApiResult<T> : ApiBaseResult
{
    /// <summary>
    /// Результат работы запроса
    /// </summary>
    public required T? Data { get; set; }
}