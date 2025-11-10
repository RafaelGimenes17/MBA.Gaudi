using MBA.Gaudi.Cursos.Application.Commands.Cursos;
using MBA.Gaudi.Cursos.Domain.Entities;
using MBA.Gaudi.Cursos.Domain.Interfaces.Repositories;
using MediatR;

namespace MBA.Gaudi.Cursos.Application.Handlers.Cursos
{
    public class ListarCursosCommandHandler : IRequestHandler<ListarCursosCommand, IEnumerable<Curso>>
    {
        private readonly ICursoRepository _cursoRepository;

        public ListarCursosCommandHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<IEnumerable<Curso>> Handle(ListarCursosCommand request, CancellationToken cancellationToken)
        {
            if (request.ApenasAtivos)
            {
                return await _cursoRepository.ObterAtivosAsync();
            }

            return await _cursoRepository.ObterTodosAsync();
        }
    }
}

