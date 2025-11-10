using MBA.Gaudi.GestaoConteudo.Application.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Handlers.Cursos
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
