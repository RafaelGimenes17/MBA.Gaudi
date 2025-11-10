using MBA.Gaudi.GestaoAlunos.Application.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Application.Handlers.Events
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
