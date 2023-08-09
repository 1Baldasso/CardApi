using DesafioAda.Domain;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace DesafioAda.Endpoints;

[HttpGet("/Test")]
[Authorize]
public class TestEndpoint : EndpointWithoutRequest<Card>
{
    public override async Task HandleAsync(CancellationToken ct)
    {
        await SendOkAsync(new Card 
        {
            Id = Guid.NewGuid(),
            Titulo = "Titulo Teste",
            Conteudo = "Conteudo Teste",
            Lista = "Lista Teste"
        });
    }
}