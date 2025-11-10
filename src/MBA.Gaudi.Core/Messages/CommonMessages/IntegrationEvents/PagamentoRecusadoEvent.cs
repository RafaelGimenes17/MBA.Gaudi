using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.Core.Messages.CommonMessages.IntegrationEvents
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
