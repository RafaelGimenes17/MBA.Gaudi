using MBA.Gaudi.Cursos.Domain.DTOs.Cursos;

namespace MBA.Gaudi.Cursos.Domain.Interfaces.Services
{
    public interface ICursoAppService : IDisposable
    {
        Task<CursoListarDto> ObterPorId(Guid id);
        Task<IEnumerable<CursoListarDto>> ObterTodos();
        Task Adicionar(CursoCriarDto cursoDto);
    }
}

