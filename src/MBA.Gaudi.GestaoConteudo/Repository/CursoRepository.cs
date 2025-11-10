using MBA.Gaudi.Core.Interfaces.Repositories;
using MBA.Gaudi.GestaoConteudo.Data.Context;
using MBA.Gaudi.GestaoConteudo.Domain;
using MBA.Gaudi.GestaoConteudo.Domain.Entities;
using MBA.Gaudi.GestaoConteudo.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Data.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ConteudoContext _context;

        public CursoRepository(ConteudoContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Curso curso)
        {
            _context.Cursos.Add(curso);
        }

        public void Alterar(Curso curso)
        {
            _context.Cursos.Update(curso);
        }

        public void Remover(Curso curso)
        {
            _context.Cursos.Remove(curso);
        }

        public async Task<Curso> BuscarPorIdAsync(Guid id)
        {
            return await _context.Cursos
                .Include(c => c.Aulas)
                .Include(c => c.ConteudoProgramatico)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Curso>> ObterTodosAsync()
        {
            return await _context.Cursos
                .Include(c => c.Aulas)
                .Include(c => c.ConteudoProgramatico)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<Curso>> ObterAtivosAsync()
        {
            return await _context.Cursos
                .Include(c => c.Aulas)
                .Include(c => c.ConteudoProgramatico)
                .Where(c => c.Ativo)
                .AsNoTracking()
                .ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
