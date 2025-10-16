using MBA.Gaudi.Cursos.Domain.Entities;

namespace MBA.Gaudi.Cursos.Domain.Interfaces.Services
{
    public interface ICursoService : IDisposable
    {
        Task<bool> VerificarAulas(Guid cursoId, Aula aula);   
    }
}