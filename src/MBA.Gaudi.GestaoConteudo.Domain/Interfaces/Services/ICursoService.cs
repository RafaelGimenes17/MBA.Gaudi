using MBA.Gaudi.GestaoConteudo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Domain.Interfaces.Services
{
    public interface ICursoService : IDisposable
    {
        Task<bool> VerificarAulas(Guid cursoId, Aula aula);
    }
}
