using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Cursos
{
    public class ObterCursoPorIdCommand : IRequest<Curso>
    {
        public Guid Id { get; set; }

        public ObterCursoPorIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
