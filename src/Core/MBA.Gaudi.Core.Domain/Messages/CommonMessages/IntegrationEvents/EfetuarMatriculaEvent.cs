using MBA.Gaudi.Core.Domain.DTOs;

namespace MBA.Gaudi.Core.Domain.Messages.CommonMessages.IntegrationEvents
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