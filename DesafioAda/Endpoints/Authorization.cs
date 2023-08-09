using DesafioAda.Model;
using DesafioAda.Services.Abstractions;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace DesafioAda.Endpoints;

[HttpPost("/token")]
[AllowAnonymous]
public class Authorization : Endpoint<TokenRequest, string>
{
    private readonly IAuthService _authService;
    public Authorization(IAuthService authService)
    {
        _authService = authService;
    }

    public override async Task HandleAsync(TokenRequest req, CancellationToken ct)
    {
        try
        {
            string token = _authService.TryLogin(req.login, req.senha);
            await SendOkAsync(token, ct);
        } 
        catch (UnauthorizedAccessException)
        {
            await SendErrorsAsync(cancellation: ct);
        }
    }
}