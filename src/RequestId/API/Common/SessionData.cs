namespace API.Common;

public class SessionData
{
    private string _requestId = Guid.NewGuid().ToString();

    public string RequestId
    {
        get => _requestId;
        set
        {
            if (!string.IsNullOrEmpty(value)) 
                _requestId = value;
        }
    }
}