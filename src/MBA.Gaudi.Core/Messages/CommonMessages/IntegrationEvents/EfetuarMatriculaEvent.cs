using MBA.Gaudi.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.Core.Messages.CommonMessages.IntegrationEvents
{
    public class EfetuarMatriculaEvent : IntegrationEvent
    {
        public Guid PedidoId { get; private set; }
        public Guid AlunoId { get; private set; }
        public ListaCursosPedidoDto ListaCursos { get; private set; }

        public EfetuarMatriculaEvent(Guid pedidoId, Guid alunoId, ListaCursosPedidoDto listaCursos)
        {
            AggregateId = pedidoId;
            PedidoId = pedidoId;
            AlunoId = alunoId;
            ListaCursos = listaCursos;
        }
    }
}
