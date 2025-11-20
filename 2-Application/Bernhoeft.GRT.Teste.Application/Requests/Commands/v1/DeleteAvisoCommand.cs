using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using MediatR;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1
{
    public class DeleteAvisoCommand : IRequest<IOperationResult<bool>>
    {
        public int Id { get; set; }

        public DeleteAvisoCommand(int id)
        {
            Id = id;
        }
    }
}