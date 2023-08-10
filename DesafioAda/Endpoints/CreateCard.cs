using DesafioAda.DataAccess;
using DesafioAda.Domain;
using DesafioAda.Model;
using DesafioAda.Processing;
using DesafioAda.Validators;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace DesafioAda.Endpoints;

[Authorize]
public class CreateCard : Endpoint<CreateCardDto, Card>
{
    private readonly ICardRepository _repository;

    public CreateCard(ICardRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Post("/cards");
        PreProcessors(new CreatePreProcessing());
    }
    [EndpointName(nameof(CreateCard))]
    public override async Task HandleAsync(CreateCardDto req, CancellationToken ct)
    {
        Card card = await _repository.CreateCard(new Card
        {
            Id = Guid.NewGuid(),
            Titulo = req.Titulo,
            Conteudo = req.Conteudo,
            Lista = req.Lista,
        });
        await SendCreatedAtAsync("cards/{id}", new { card.Id }, card, cancellation: ct);
    }
}
