namespace MBA.Gaudi.Core.Domain.Messages.CommonMessages.IntegrationEvents
{
    public class PagamentoRecusadoEvent : IntegrationEvent
    {
        public Guid PedidoId { get; private set; }
        
        public PagamentoRecusadoEvent(Guid pedidoId)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
        }
    }
}
