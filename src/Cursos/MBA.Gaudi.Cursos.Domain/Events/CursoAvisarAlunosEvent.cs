using MBA.Gaudi.Core.Domain.Messages;

namespace MBA.Gaudi.Cursos.Domain.Events
{
    public class CursoAvisarAlunosEvent : DomainEvent
    {
        private readonly string Aula;
        public CursoAvisarAlunosEvent(Guid aggregateId, string aula) : base(aggregateId)
        {
            Aula = aula;
        }
    }
}

