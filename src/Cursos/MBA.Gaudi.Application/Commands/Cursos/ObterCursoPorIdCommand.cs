using MBA.Gaudi.Cursos.Domain.Entities;
using MediatR;

namespace MBA.Gaudi.Cursos.Application.Commands.Cursos
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

