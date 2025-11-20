using FluentValidation;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations
{
    public class UpdateAvisoCommandValidation : AbstractValidator<UpdateAvisoCommand>
    {
        public UpdateAvisoCommandValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O ID deve ser maior que zero");

            RuleFor(x => x.Mensagem)
                .NotEmpty().WithMessage("A mensagem é obrigatória")
                .NotNull().WithMessage("A mensagem é obrigatória");
        }
    }
}
