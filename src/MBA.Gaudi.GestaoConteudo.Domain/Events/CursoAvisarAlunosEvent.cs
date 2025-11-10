using MBA.Gaudi.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Domain.Events
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
