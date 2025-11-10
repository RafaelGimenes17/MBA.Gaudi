using MBA.Gaudi.Core.Domain.Interfaces.Mediator;
using MBA.Gaudi.Core.Domain.Messages;
using MediatR;

namespace MBA.Gaudi.Core.Domain.Mediator
{
    public class MediatorHandler :  IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)  
        {
            _mediator = mediator;  
        }
        
        public async Task PublicarEvento<T>(T evento) where T : Event
        {
            await _mediator.Publish(evento);
        }

        public async Task<bool> EnviarComando<T>(T comando) where T : Command
        {
            return await _mediator.Send(comando);
        }

        public async Task<TResponse> EnviarComando<TResponse>(IRequest<TResponse> comando)
        {
            return await _mediator.Send(comando);
        }
    }
}