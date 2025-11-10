using MBA.Gaudi.GestaoConteudo.Domain.Interfaces.Repositories;

using MBA.Gaudi.Core.Interfaces.Repositories;
using MBA.Gaudi.GestaoConteudo.Data.Context;
using MBA.Gaudi.GestaoConteudo.Domain.Entities;

using Microsoft.EntityFrameworkCore;


namespace MBA.Gaudi.GestaoConteudo.Data.Repository
{
    public class AulaRepository : IAulaRepository
    {
        private readonly ConteudoContext _context;

        public AulaRepository(ConteudoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Aula aula)
        {
            _context.Aulas.Add(aula);
        }

        public void Alterar(Aula aula)
        {
            _context.Aulas.Update(aula);
        }

        public void Remover(Aula aula)
        {
            _context.Aulas.Remove(aula);
        }

        public async Task<Aula?> BuscarPorIdAsync(Guid id)
        {
            return await _context.Aulas
                .Include(a => a.Curso)
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Aula>> ObterTodasAsync()
        {
            return await _context.Aulas
                .AsNoTracking()
                .OrderBy(a => a.Ordem)
                .ToListAsync();
        }

        public async Task<IEnumerable<Aula>> ObterAtivasAsync()
        {
            return await _context.Aulas
                .Where(a => a.Ativa)
                .AsNoTracking()
                .OrderBy(a => a.Ordem)
                .ToListAsync();
        }

        public async Task<IEnumerable<Aula>> ObterPorCursoIdAsync(Guid cursoId)
        {
            return await _context.Aulas
                .Where(a => a.CursoId == cursoId)
                .AsNoTracking()
                .OrderBy(a => a.Ordem)
                .ToListAsync();
        }

        public async Task<IEnumerable<Aula>> ObterAtivasPorCursoIdAsync(Guid cursoId)
        {
            return await _context.Aulas
                .Where(a => a.CursoId == cursoId && a.Ativa)
                .AsNoTracking()
                .OrderBy(a => a.Ordem)
                .ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
