using System.Net.Http.Headers;

namespace API.Common;

public class HttpSendHelper
{
    private readonly HttpClient _httpClient;
    private readonly SessionData _sessionData;

    public HttpSendHelper(
        HttpClient httpClient,
        SessionData sessionData)
    {
        _httpClient = httpClient;
        _sessionData = sessionData;
    }
    
    public async Task<string> GetRequestAsync(string url, CancellationToken cancellationToken)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("X-Request-Id", _sessionData.RequestId);
        
        var response = await _httpClient.SendAsync(request, cancellationToken);
        string stringResult = await response.Content.ReadAsStringAsync(cancellationToken);

        return stringResult;
    }
}