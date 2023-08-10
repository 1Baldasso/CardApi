using DesafioAda.DataAccess;
using DesafioAda.Domain;
using DesafioAda.Exceptions;
using DesafioAda.Model;
using DesafioAda.Processing;
using FastEndpoints;
using FluentValidation.Results;

namespace DesafioAda.Endpoints;

public class UpdateCard : Endpoint<UpdateCardDto, Card>
{
    private readonly ICardRepository _repository;

    public UpdateCard(ICardRepository repository)
    {
        _repository = repository;
    }

    public override void Configure()
    {
        Put("/cards/{routeId}");
        PostProcessors(new UpdateCardLogger());
        PreProcessors(new UpdatePreProcessing());
    }

    [EndpointName(nameof(UpdateCard))]
    public override async Task HandleAsync(UpdateCardDto req, CancellationToken ct)
    {
        if(req.Id != req.RouteId)
        {
            this.ValidationFailures.Add(new ValidationFailure
            {
                ErrorMessage = "O id do corpo da requisição deve corresponder ao id da rota",
            });
            await SendErrorsAsync(cancellation: ct);
            return;
        }
        Card card = null;
        try
        {
            card = await _repository.UpdateCard(new Card
            {
                Id = req.Id,
                Titulo = req.Titulo,
                Conteudo = req.Conteudo,
                Lista = req.Lista,
            });
        }
        catch (EntityNotFoundException)
        {
            await SendNotFoundAsync();
            return;
        }

        await SendOkAsync(card, cancellation: ct);
    }
}
