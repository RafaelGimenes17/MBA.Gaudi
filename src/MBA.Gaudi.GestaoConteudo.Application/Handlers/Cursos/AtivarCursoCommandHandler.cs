using MBA.Gaudi.GestaoConteudo.Application.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Handlers.Cursos
{
    public class AtivarCursoCommandHandler : IRequestHandler<AtivarCursoCommand, bool>
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMediator _mediator;

        public AtivarCursoCommandHandler(ICursoRepository cursoRepository, IMediator mediator)
        {
            _cursoRepository = cursoRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(AtivarCursoCommand request, CancellationToken cancellationToken)
        {
            var curso = await _cursoRepository.BuscarPorIdAsync(request.CursoId);

            if (curso != null)
            {
                curso.Ativar();
                _cursoRepository.Alterar(curso);
                return await _cursoRepository.UnitOfWork.Commit();
            }

            return false;
        }
    }
}
