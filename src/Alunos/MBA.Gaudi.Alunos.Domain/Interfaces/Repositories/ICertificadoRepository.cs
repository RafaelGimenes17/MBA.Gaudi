using MBA.Gaudi.Alunos.Domain.Entities;

namespace MBA.Gaudi.Alunos.Domain.Interfaces.Repositories
{
    public interface ICertificadoRepository : IDisposable
    {
        void Adicionar(Certificado certificado);
        Certificado? BuscarPorId(Guid id);
        Certificado? BuscarPorAlunoECurso(Guid alunoId, Guid cursoId);
        List<Certificado> BuscarPorAluno(Guid alunoId);
    }
}

