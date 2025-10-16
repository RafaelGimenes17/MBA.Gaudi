using MBA.Gaudi.Core.Domain.Messages;
using MediatR;

namespace MBA.Gaudi.Core.Domain.Interfaces.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task<TResponse> EnviarComando<TResponse>(IRequest<TResponse> comando);
    }
}

