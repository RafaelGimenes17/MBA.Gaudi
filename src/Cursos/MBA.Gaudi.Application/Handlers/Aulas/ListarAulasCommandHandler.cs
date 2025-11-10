using MBA.Gaudi.Cursos.Application.Commands.Aulas;
using MBA.Gaudi.Cursos.Domain.Entities;
using MBA.Gaudi.Cursos.Domain.Interfaces.Repositories;
using MediatR;

namespace MBA.Gaudi.Cursos.Application.Handlers.Aulas
{
    public class ListarAulasCommandHandler : IRequestHandler<ListarAulasCommand, IEnumerable<Aula>>
    {
        private readonly IAulaRepository _aulaRepository;

        public ListarAulasCommandHandler(IAulaRepository aulaRepository)
        {
            _aulaRepository = aulaRepository;
        }

        public async Task<IEnumerable<Aula>> Handle(ListarAulasCommand request, CancellationToken cancellationToken)
        {
            // Se foi especificado um curso, filtrar por curso
            if (request.CursoId.HasValue)
            {
                return request.ApenasAtivas
                    ? await _aulaRepository.ObterAtivasPorCursoIdAsync(request.CursoId.Value)
                    : await _aulaRepository.ObterPorCursoIdAsync(request.CursoId.Value);
            }

            // Caso contrário, retornar todas as aulas
            return request.ApenasAtivas
                ? await _aulaRepository.ObterAtivasAsync()
                : await _aulaRepository.ObterTodasAsync();
        }
    }
}

