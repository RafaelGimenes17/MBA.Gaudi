using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Commands.Aulas
{
    public class ObterAulaPorIdCommand : IRequest<Aula?>
    {
        public Guid Id { get; set; }

        public ObterAulaPorIdCommand(Guid id)
        {
            Id = id;
        }
    }
}
