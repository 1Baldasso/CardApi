using DesafioAda.DataAccess;
using DesafioAda.Domain;
using DesafioAda.Model;
using FastEndpoints;
using FluentValidation.Results;

public class DeleteCardLogger : IPostProcessor<CardByIdDto, IEnumerable<Card>>
{
    public Task PostProcessAsync(CardByIdDto req, IEnumerable<Card> res, HttpContext ctx, IReadOnlyCollection<ValidationFailure> failures, CancellationToken ct)
    {
        if (ctx.Response.StatusCode == 200)
        {
            var logger = ctx.Resolve<Serilog.ILogger>();
            var title = ctx.Response.Headers["Deleted-Card-Title"];
            logger.Information($"{DateTime.Now.ToLocalTime():dd/MM/yy HH:mm:ss} - Card {req.Id} - {title} - Removido.");
        }
        return Task.CompletedTask;
    }
}
