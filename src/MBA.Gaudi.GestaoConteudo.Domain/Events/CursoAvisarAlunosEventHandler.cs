using MBA.Gaudi.GestaoConteudo.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Domain.Events
{
    public class CursoAvisarAlunosEventHandler : INotificationHandler<CursoAvisarAlunosEvent>
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoAvisarAlunosEventHandler(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task Handle(CursoAvisarAlunosEvent notification, CancellationToken cancellationToken)
        {
            var curso = await _cursoRepository.BuscarPorIdAsync(notification.AggregateId);
        }
    }
}
