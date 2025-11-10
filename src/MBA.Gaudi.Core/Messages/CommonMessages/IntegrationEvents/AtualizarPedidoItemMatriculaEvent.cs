using MBA.Gaudi.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.Core.Messages.CommonMessages.IntegrationEvents
{
    public class AtualizarPedidoItemMatriculaEvent : IntegrationEvent
    {
        public Guid PedidoId { get; private set; }
        public List<MatriculaItemDto> Matriculas { get; private set; }

        public AtualizarPedidoItemMatriculaEvent(Guid pedidoId, List<MatriculaItemDto> matriculas)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            Matriculas = matriculas ?? new List<MatriculaItemDto>();
        }
    }
}
