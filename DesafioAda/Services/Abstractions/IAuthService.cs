namespace DesafioAda.Services.Abstractions;

public interface IAuthService
{
    string TryLogin(string login, string senha);
}
