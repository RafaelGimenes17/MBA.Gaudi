using MBA.Gaudi.Cursos.Application.Commands.Cursos;
using MBA.Gaudi.Cursos.Domain.Entities;
using MBA.Gaudi.Cursos.Domain.Interfaces.Repositories;
using MediatR;

namespace MBA.Gaudi.Cursos.Application.Handlers.Cursos
{
    public class ObterCursoPorIdCommandHandler : IRequestHandler<ObterCursoPorIdCommand, Curso>
    {
        private readonly ICursoRepository _cursoRepository;

        public ObterCursoPorIdCommandHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<Curso> Handle(ObterCursoPorIdCommand request, CancellationToken cancellationToken)
        {
            return await _cursoRepository.BuscarPorIdAsync(request.Id);
        }
    }
}

