namespace API.Services;
using API.Common;

public class RequestIdService
{
    private readonly SessionData _sessionData;
    public RequestIdService(SessionData sessionData)
    {
        _sessionData = sessionData;
    }
    public void PrintRequestId()
    {
        Console.WriteLine($"RequestIdService request_id: {_sessionData.RequestId}");
    }
}