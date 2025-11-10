using MBA.Gaudi.Alunos.Application.Commands;
using MBA.Gaudi.Core.Application.Events.Identity;
using MediatR;

namespace MBA.Gaudi.Alunos.Application.Handlers.Events
{
    public class UsuarioCriadoEventHandler : INotificationHandler<UsuarioCriadoEvent>
    {
        private readonly IMediator _mediator;

        public UsuarioCriadoEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Handle(UsuarioCriadoEvent notification, CancellationToken cancellationToken)
        {
            var command = new CriarAlunoCommand(
                notification.UsuarioId,
                notification.Nome,
                notification.Email
            );

            await _mediator.Send(command, cancellationToken);
        }
    }
}

