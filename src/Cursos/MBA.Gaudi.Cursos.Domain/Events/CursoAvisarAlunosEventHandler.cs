using System.Runtime.InteropServices.ComTypes;
using MBA.Gaudi.Cursos.Domain.Interfaces.Repositories;
using MediatR;

namespace MBA.Gaudi.Cursos.Domain.Events
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