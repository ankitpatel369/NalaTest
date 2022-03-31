namespace NalaTest.Application.Interfaces.Base
{
    public interface IWebRequestService
    {
        Task<string?> HttpClientRequest(string url, string? accessToken, object? requestBody, HttpMethod methodType, IDictionary<string, string>? headers = null);
    }
}
