using MBA.Gaudi.Core.Domain.Notifications;

namespace MBA.Gaudi.Core.Domain.Interfaces.Notifications
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}

