using API.Common;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("request_id")]
public class RequestIdController: Controller
{
    private readonly SessionData _sessionData;
    private readonly RequestIdService _requestIdService;
    private readonly ExternalApiService _externalApiService;

    public RequestIdController(
        SessionData sessionData,
        RequestIdService requestIdService,
        ExternalApiService externalApiService)
    {
        _sessionData = sessionData;
        _requestIdService = requestIdService;
        _externalApiService = externalApiService;
    }

    [HttpGet]
    public ActionResult<string> Get()
    {
        _requestIdService.PrintRequestId();
        return _sessionData.RequestId;
    }
    
    [HttpGet("external")]
    public Task<string> GetExternal(CancellationToken cancellationToken)
    {
        return _externalApiService.GetRequestIdAsync(cancellationToken);
    }
}