using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Domain.Interfaces.Services
{
    public interface ICertificadoPdfService
    {
        Task<byte[]> GerarCertificadoPdfAsync(
            string nomeAluno,
            string nomeCurso,
            DateTime dataConclusao,
            string codigoCertificado);
    }
}
