using Bernhoeft.GRT.ContractWeb.Domain.SqlServer.ContractStore.Interfaces.Repositories;
using Bernhoeft.GRT.Core.EntityFramework.Domain.Interfaces;
using Bernhoeft.GRT.Core.Interfaces.Results;
using Bernhoeft.GRT.Core.Models;
using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bernhoeft.GRT.Teste.Application.Handlers.Commands.v1
{
    public class UpdateAvisoHandler : IRequestHandler<UpdateAvisoCommand, IOperationResult<bool>>
    {
        private readonly IServiceProvider _serviceProvider;
        private IAvisoRepository _avisoRepository => _serviceProvider.GetRequiredService<IAvisoRepository>();
        private IContext _context => _serviceProvider.GetRequiredService<IContext>();

        public UpdateAvisoHandler(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task<IOperationResult<bool>> Handle(UpdateAvisoCommand request, CancellationToken cancellationToken)
        {
            var aviso = await _avisoRepository.ObterAvisoPorIdAsync(request.Id);

            if (aviso == null || !aviso.Ativo)
                return OperationResult<bool>.ReturnNotFound();

            aviso.Mensagem = request.Mensagem;
            aviso.DataEdicao = DateTime.UtcNow;

            _avisoRepository.Update(aviso);
            await _context.SaveChangesAsync(cancellationToken);

            return OperationResult<bool>.ReturnOk(true);
        }
    }
}