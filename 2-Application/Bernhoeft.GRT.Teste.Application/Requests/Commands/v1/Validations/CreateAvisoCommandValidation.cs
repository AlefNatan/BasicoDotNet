using FluentValidation;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations
{
    public class CreateAvisoCommandValidation : AbstractValidator<CreateAvisoCommand>
    {
        public CreateAvisoCommandValidation()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório")
                .NotNull().WithMessage("O título é obrigatório");

            RuleFor(x => x.Mensagem)
                .NotEmpty().WithMessage("A mensagem é obrigatória")
                .NotNull().WithMessage("A mensagem é obrigatória");
        }
    }
}
