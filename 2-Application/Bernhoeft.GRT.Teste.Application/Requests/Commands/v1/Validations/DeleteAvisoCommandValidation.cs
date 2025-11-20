using FluentValidation;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validations
{
    public class DeleteAvisoCommandValidation : AbstractValidator<DeleteAvisoCommand>
    {
        public DeleteAvisoCommandValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O ID deve ser maior que zero");
        }
    }
}