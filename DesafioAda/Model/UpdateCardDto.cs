using Microsoft.AspNetCore.Mvc;

namespace DesafioAda.Model;

public record UpdateCardDto
{
    [FromRoute] public Guid RouteId { get; init; }
    [FromBody] public Guid Id { get; init; }
    [FromBody] public string Titulo { get; init; }
    [FromBody] public string Conteudo { get; init; }
    [FromBody] public string Lista { get; init; }
}
