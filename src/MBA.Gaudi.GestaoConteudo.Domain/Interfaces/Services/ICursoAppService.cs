using MBA.Gaudi.GestaoConteudo.Domain.DTOs.Cursos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Domain.Interfaces.Services
{
    public interface ICursoAppService : IDisposable
    {
        Task<CursoListarDto> ObterPorId(Guid id);
        Task<IEnumerable<CursoListarDto>> ObterTodos();
        Task Adicionar(CursoCriarDto cursoDto);
    }
}
