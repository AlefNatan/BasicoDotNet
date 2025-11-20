using FluentValidation;
using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;

namespace Bernhoeft.GRT.Teste.Application.Requests.Queries.v1.Validations
{
    public class GetAvisoRequestValidation : AbstractValidator<GetAvisoRequest>
    {
        public GetAvisoRequestValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O ID deve ser maior que zero");
        }
    }
}