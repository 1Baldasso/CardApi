using DesafioAda.Domain;
using DesafioAda.Services.Abstractions;
using FastEndpoints;

namespace DesafioAda.Endpoints;

[HttpGet("/cards")]
public class GetCards : EndpointWithoutRequest<IEnumerable<Card>>
{
    private readonly ICardRepository _repository;

    public GetCards(ICardRepository repository)
    {
        _repository = repository;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        IEnumerable<Card> cards = _repository.ListCards();
        await SendOkAsync(cards, ct);
    }
}
