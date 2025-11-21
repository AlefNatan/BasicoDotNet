using Bernhoeft.GRT.Core.Interfaces.Results;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1
{
    public class UpdateAvisoCommand : IRequest<IOperationResult<bool>>
    {
        public int Id { get; set; }
        public string Mensagem { get; set; }

        public UpdateAvisoCommand(int id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }

    public class UpdateAvisoRequest
    {
        public string Mensagem { get; set; }
    }
}