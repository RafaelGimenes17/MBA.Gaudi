using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Domain
{
    public class HistoricoAprendizado
    {
        public HistoricoAprendizado() { }
        public HistoricoAprendizado(Guid alunoId, Guid cursoId, DateTime dataAprendizado)
        {
            AulaId = alunoId;
            CursoId = cursoId;
            DataAprendizado = dataAprendizado;
        }

        public Guid AulaId { get; private set; }
        public Guid CursoId { get; private set; }
        public DateTime DataAprendizado { get; private set; }

    }
}
