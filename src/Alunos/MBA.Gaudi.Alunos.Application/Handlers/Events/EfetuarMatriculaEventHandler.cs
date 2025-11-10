using MBA.Gaudi.Alunos.Application.Commands;
using MBA.Gaudi.Core.Domain.Interfaces.Mediator;
using MBA.Gaudi.Core.Domain.Messages.CommonMessages.IntegrationEvents;
using MediatR;

namespace MBA.Gaudi.Alunos.Application.Handlers.Events
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
