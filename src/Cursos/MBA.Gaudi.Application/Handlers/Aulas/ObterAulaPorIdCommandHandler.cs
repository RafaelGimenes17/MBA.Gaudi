using MBA.Gaudi.Cursos.Application.Commands.Aulas;
using MBA.Gaudi.Cursos.Domain.Entities;
using MBA.Gaudi.Cursos.Domain.Interfaces.Repositories;
using MediatR;

namespace MBA.Gaudi.Cursos.Application.Handlers.Aulas
{
    public class ObterAulaPorIdCommandHandler : IRequestHandler<ObterAulaPorIdCommand, Aula?>
    {
        private readonly IAulaRepository _aulaRepository;

        public ObterAulaPorIdCommandHandler(IAulaRepository aulaRepository)
        {
            _aulaRepository = aulaRepository;
        }

        public async Task<Aula?> Handle(ObterAulaPorIdCommand request, CancellationToken cancellationToken)
        {
            return await _aulaRepository.BuscarPorIdAsync(request.Id);
        }
    }
}

