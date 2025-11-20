using Bernhoeft.GRT.Core.Interfaces.Results;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1
{
    public class UpdateAvisoCommand : IRequest<IOperationResult<bool>>
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public int Id { get; set; }
        public string Mensagem { get; set; }

        public UpdateAvisoCommand(int id, string mensagem)
        {
            Id = id;
            Mensagem = mensagem;
        }
    }
}