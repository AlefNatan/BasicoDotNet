using Bernhoeft.GRT.Core.Interfaces.Results;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1
{
    public class CreateAvisoCommand : IRequest<IOperationResult<int>>
    {
        public string Titulo { get; set; }
        public string Mensagem { get; set; }

        public CreateAvisoCommand(string titulo, string mensagem)
        {
            Titulo = titulo;
            Mensagem = mensagem;
        }
    }
}