using MBA.Gaudi.GestaoAlunos.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Domain.Interfaces.Repositories
{
    public interface ICertificadoRepository : IDisposable
    {
        void Adicionar(Certificado certificado);
        Certificado? BuscarPorId(Guid id);
        Certificado? BuscarPorAlunoECurso(Guid alunoId, Guid cursoId);
        List<Certificado> BuscarPorAluno(Guid alunoId);
    }
}
