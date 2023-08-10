using DesafioAda.Domain;
using FluentValidation;

namespace DesafioAda.Validators
{
    public class CardValidator : AbstractValidator<Card>
    {
        public CardValidator() 
        {
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .NotNull()
                .MaximumLength(50)
                .WithMessage("Informe o título");
            RuleFor(x => x.Conteudo)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Lista).NotEmpty();
        }
    }
}
