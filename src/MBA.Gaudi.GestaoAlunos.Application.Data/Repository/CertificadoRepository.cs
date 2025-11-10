using MBA.Gaudi.GestaoAlunos.Data.Context;
using MBA.Gaudi.GestaoAlunos.Domain.Entites;
using MBA.Gaudi.GestaoAlunos.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Data.Repository
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
