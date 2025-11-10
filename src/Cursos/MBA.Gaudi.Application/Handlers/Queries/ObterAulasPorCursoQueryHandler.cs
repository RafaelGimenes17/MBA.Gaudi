using MBA.Gaudi.Cursos.Application.Queries;
using MBA.Gaudi.Cursos.Domain.Entities;
using MBA.Gaudi.Cursos.Domain.Interfaces.Repositories;
using MediatR;

namespace MBA.Gaudi.Cursos.Application.Handlers.Queries
{
    public class ObterAulasPorCursoQueryHandler : IRequestHandler<ObterAulasPorCursoQuery, IEnumerable<Aula>>
    {
        private readonly IAulaRepository _aulaRepository;

        public ObterAulasPorCursoQueryHandler(IAulaRepository aulaRepository)
        {
            _aulaRepository = aulaRepository;
        }

        public async Task<IEnumerable<Aula>> Handle(ObterAulasPorCursoQuery request, CancellationToken cancellationToken)
        {
            var aulas = await _aulaRepository.ObterAtivasPorCursoIdAsync(request.CursoId);
            return aulas;
        }
    }
}

