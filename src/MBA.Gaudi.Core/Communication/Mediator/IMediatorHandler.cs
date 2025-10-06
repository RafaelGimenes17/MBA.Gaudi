using MBA.Gaudi.Core.Messages;
using MBA.Gaudi.Core.Messages.CommonMessages;
using MBA.Gaudi.Core.Messages.DomainEvent;
using MBA.Gaudi.Core.Messages.Notifications;

namespace MBA.Gaudi.Core.Communication.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
        Task PublicarDomainEvent<T>(T notificacao) where T : DomainEvent;
    }
}