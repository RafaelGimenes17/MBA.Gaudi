using MBA.Gaudi.GestaoConteudo.Application.Queries;
using MBA.Gaudi.GestaoConteudo.Domain.Entities;
using MBA.Gaudi.GestaoConteudo.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Handlers.Queries
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
