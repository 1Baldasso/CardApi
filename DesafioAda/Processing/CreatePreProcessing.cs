using DesafioAda.Domain;
using DesafioAda.Model;
using DesafioAda.Validators;
using FastEndpoints;
using FluentValidation.Results;

namespace DesafioAda.Processing;

public class CreatePreProcessing : IPreProcessor<CreateCardDto>
{
    public Task PreProcessAsync(CreateCardDto req, HttpContext ctx, List<ValidationFailure> failures, CancellationToken ct)
    {
        if(req is null)
        {
            failures.Add(new ValidationFailure(nameof(req), "Request should not be null"));
            return ctx.Response.SendErrorsAsync(failures);
        }
        var validator = new CardValidator();
        var result = validator.Validate(
            new Card
            {
                Lista = req.Lista,
                Conteudo = req.Conteudo,
                Titulo = req.Titulo
            });
        if (!result.IsValid)
        {
            failures.AddRange(result.Errors);
            return ctx.Response.SendErrorsAsync(failures);
        }
        return Task.CompletedTask;
    }
}
