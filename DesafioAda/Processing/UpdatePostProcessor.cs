using DesafioAda.Domain;
using DesafioAda.Model;
using FastEndpoints;
using FluentValidation.Results;

namespace DesafioAda.Processing;

public class UpdateCardLogger : IPostProcessor<UpdateCardDto, Card>
{
    public Task PostProcessAsync(UpdateCardDto req, Card res, HttpContext ctx, IReadOnlyCollection<ValidationFailure> failures, CancellationToken ct)
    {
        if(ctx.Response.StatusCode == 200)
        {
            var logger = ctx.Resolve<Serilog.ILogger>();
            logger.Information($"{DateTime.Now.ToLocalTime():dd/MM/yy HH:mm:ss} - Card {res.Id} - {res.Titulo} - Alterado.");
        }
        return Task.CompletedTask;
    }
}
