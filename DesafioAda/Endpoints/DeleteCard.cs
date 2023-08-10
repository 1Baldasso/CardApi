using DesafioAda.DataAccess;
using DesafioAda.Domain;
using DesafioAda.Model;
using FastEndpoints;

namespace DesafioAda.Endpoints;

public class DeleteCard : Endpoint<CardByIdDto,IEnumerable<Card>>
{
    private readonly ICardRepository _repository;

    public DeleteCard(ICardRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Delete("cards/{id}");
        PostProcessors(new DeleteCardLogger());
    }

    [EndpointName(nameof(DeleteCard))]
    public override async Task HandleAsync(CardByIdDto req, CancellationToken ct)
    {
        var card = _repository.GetCard(req.Id);
        _repository.DeleteCard(req.Id);
        HttpContext.Response.Headers.Add("Deleted-Card-Title", card.Titulo);
        await SendOkAsync(_repository.ListCards());
    }
}
