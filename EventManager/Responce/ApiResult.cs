using System.Net;

namespace EventManager.Responce;

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

/// <summary>
/// Базовый класс с основными возвращаемыми параметрами
/// </summary>
public class ApiBaseResult
{
    /// <summary>
    /// Возвращаемый HTTP-код
    /// </summary>
    public required HttpStatusCode StatusCode { get; set; }
    /// <summary>
    /// Кастомное сообщение с дополнительной информацией
    /// Здесь может быть информация об ошибке в случае неуспеха
    /// </summary>
    public required string Message { get; set; }
} 