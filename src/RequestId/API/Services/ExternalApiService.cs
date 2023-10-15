using API.Common;

namespace API.Services;

public class ExternalApiService
{
    private readonly HttpSendHelper _httpSendHelper;

    public ExternalApiService(HttpSendHelper httpSendHelper)
    {
        _httpSendHelper = httpSendHelper;
    }

    public Task<string> GetRequestIdAsync(CancellationToken cancellationToken)
    {
        return _httpSendHelper.GetRequestAsync("http://localhost:5000/request_id", cancellationToken);
    }
}