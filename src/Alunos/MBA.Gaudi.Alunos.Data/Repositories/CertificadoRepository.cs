using MBA.Gaudi.Alunos.Data.Context;
using MBA.Gaudi.Alunos.Domain.Entities;
using MBA.Gaudi.Alunos.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MBA.Gaudi.Alunos.Data.Repositories
{
    public class CertificadoRepository : ICertificadoRepository
    {
        private readonly AlunoContext _context;

        public CertificadoRepository(AlunoContext context)
        {
            _context = context;
        }

        public void Adicionar(Certificado certificado)
        {
            _context.Certificados.Add(certificado);
        }

        public Certificado? BuscarPorId(Guid id)
        {
            return _context.Certificados
                .FirstOrDefault(c => c.Id == id);
        }

        public Certificado? BuscarPorAlunoECurso(Guid alunoId, Guid cursoId)
        {
            return _context.Alunos
                .Where(a => a.Id == alunoId)
                .SelectMany(a => a.Certificados)
                .FirstOrDefault(c => c.CursoId == cursoId && c.Ativo);
        }

        public List<Certificado> BuscarPorAluno(Guid alunoId)
        {
            return _context.Alunos
                .Where(a => a.Id == alunoId)
                .SelectMany(a => a.Certificados)
                .Where(c => c.Ativo)
                .ToList();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

