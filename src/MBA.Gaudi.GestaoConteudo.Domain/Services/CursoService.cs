using MBA.Gaudi.Core.Interfaces.Mediator;
using MBA.Gaudi.GestaoConteudo.Domain.Entities;
using MBA.Gaudi.GestaoConteudo.Domain.Events;
using MBA.Gaudi.GestaoConteudo.Domain.Interfaces.Repositories;
using MBA.Gaudi.GestaoConteudo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Domain.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public CursoService(ICursoRepository cursoRepository, IMediatorHandler mediatorHandler)
        {
            _cursoRepository = cursoRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> VerificarAulas(Guid cursoId, Aula aula)
        {
            var curso = await _cursoRepository.BuscarPorIdAsync(cursoId);

            var teste = curso.Aulas.FirstOrDefault(p => p.Descricao.Equals(aula.Descricao));

            if (teste != null) return false;

            await _mediatorHandler.PublicarEvento(new CursoAvisarAlunosEvent(cursoId, aula.Descricao));

            return true;
        }

        public void Dispose()
        {
            _cursoRepository.Dispose();
        }
    }
}
