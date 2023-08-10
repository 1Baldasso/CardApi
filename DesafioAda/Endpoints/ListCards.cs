using DesafioAda.DataAccess;
using DesafioAda.Domain;
using FastEndpoints;

namespace DesafioAda.Endpoints;

[HttpGet("/cards")]
public class ListCards : EndpointWithoutRequest<IEnumerable<Card>>
{
    private readonly ICardRepository _repository;

    public ListCards(ICardRepository repository)
    {
        _repository = repository;
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        IEnumerable<Card> cards = await _repository.GetAllCards();
        await SendOkAsync(cards, ct);
    }
}
