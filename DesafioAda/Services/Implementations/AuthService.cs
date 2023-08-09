using DesafioAda.Services.Abstractions;

namespace DesafioAda.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;

    public AuthService(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public string TryLogin(string login, string senha)
    {
        if (login == "letscode" && senha == "lets@123")
            return _tokenService.GenerateToken();
        throw new UnauthorizedAccessException("Credenciais Inválidas");
    }
}
