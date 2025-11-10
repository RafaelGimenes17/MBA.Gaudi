using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Cursos
{
    public class ListarCursosCommand : IRequest<IEnumerable<Curso>>
    {
        public bool ApenasAtivos { get; set; }

        public ListarCursosCommand(bool apenasAtivos = false)
        {
            ApenasAtivos = apenasAtivos;
        }
    }
}
