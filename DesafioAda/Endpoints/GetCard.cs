using DesafioAda.DataAccess;
using DesafioAda.Domain;
using DesafioAda.Model;
using FastEndpoints;

namespace DesafioAda.Endpoints;

[HttpGet("cards/{Id}")]
public class GetCard : Endpoint<CardByIdDto,Card>
{
    private readonly ICardRepository _cardRepository;

    public GetCard(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    [EndpointName(nameof(GetCard))]
    public override async Task HandleAsync(CardByIdDto dto, CancellationToken ct)
    {
        Card card = _cardRepository.GetCard(dto.Id);
        await SendOkAsync(card, ct);
    }
}
