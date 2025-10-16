using MBA.Gaudi.Cursos.Domain.Entities;
using MediatR;

namespace MBA.Gaudi.Cursos.Application.Commands.Cursos
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

