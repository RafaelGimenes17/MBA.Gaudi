using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Commands.Aulas
{
    public class ListarAulasCommand : IRequest<IEnumerable<Aula>>
    {
        public Guid? CursoId { get; set; }
        public bool ApenasAtivas { get; set; }

        public ListarAulasCommand(Guid? cursoId = null, bool apenasAtivas = false)
        {
            CursoId = cursoId;
            ApenasAtivas = apenasAtivas;
        }
    }
}
