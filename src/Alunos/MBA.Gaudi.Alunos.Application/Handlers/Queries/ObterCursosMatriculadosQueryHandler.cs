using MBA.Gaudi.Alunos.Application.Queries;
using MBA.Gaudi.Alunos.Domain.Entities;
using MBA.Gaudi.Alunos.Domain.Interfaces.Repositories;
using MediatR;

namespace MBA.Gaudi.Alunos.Application.Handlers.Queries
{
    public class ObterCursosMatriculadosQueryHandler : IRequestHandler<ObterCursosMatriculadosQuery, IEnumerable<Matricula>>
    {
        private readonly IMatriculaRepository _matriculaRepository;

        public ObterCursosMatriculadosQueryHandler(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public async Task<IEnumerable<Matricula>> Handle(ObterCursosMatriculadosQuery request, CancellationToken cancellationToken)
        {
            var matriculas = _matriculaRepository.BuscarPorAluno(request.AlunoId);
            return await Task.FromResult(matriculas);
        }
    }
}

