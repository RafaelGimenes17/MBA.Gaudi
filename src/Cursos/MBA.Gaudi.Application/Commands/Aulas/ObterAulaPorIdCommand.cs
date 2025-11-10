using MBA.Gaudi.Cursos.Domain.Entities;
using MediatR;

namespace MBA.Gaudi.Cursos.Application.Commands.Aulas
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

