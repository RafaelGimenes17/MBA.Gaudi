using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Queries
{
    public class ObterAulasPorCursoQuery : IRequest<IEnumerable<Aula>>
    {
        public Guid CursoId { get; set; }

        public ObterAulasPorCursoQuery(Guid cursoId)
        {
            CursoId = cursoId;
        }
    }
}
