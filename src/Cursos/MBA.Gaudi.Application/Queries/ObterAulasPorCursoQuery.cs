using MBA.Gaudi.Cursos.Domain.Entities;
using MediatR;

namespace MBA.Gaudi.Cursos.Application.Queries
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

