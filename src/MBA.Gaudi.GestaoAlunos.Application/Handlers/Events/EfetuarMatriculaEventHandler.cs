using MBA.Gaudi.Core.Interfaces.Mediator;
using MBA.Gaudi.Core.Messages.CommonMessages.IntegrationEvents;
using MBA.Gaudi.GestaoAlunos.Application.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Application.Handlers.Events
{
    public class EfetuarMatriculaEventHandler : INotificationHandler<EfetuarMatriculaEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public EfetuarMatriculaEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public async Task Handle(EfetuarMatriculaEvent message, CancellationToken cancellationToken)
        {
            var processarMatriculaCommand = new ProcessarMatriculaCommand(
                message.AlunoId,
                message.PedidoId,
                message.ListaCursos);

            await _mediatorHandler.EnviarComando(processarMatriculaCommand);
        }
    }
}
