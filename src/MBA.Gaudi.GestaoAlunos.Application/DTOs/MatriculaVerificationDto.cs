using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoAlunos.Application.DTOs
{
    public class MatriculaVerificationDto
    {
        public Guid CursoId { get; set; }
        public bool EstaMatriculado { get; set; }
        public bool MatriculaAtiva { get; set; }
        public DateTime? DataMatricula { get; set; }

        public MatriculaVerificationDto(Guid cursoId, bool estaMatriculado, bool matriculaAtiva, DateTime? dataMatricula = null)
        {
            CursoId = cursoId;
            EstaMatriculado = estaMatriculado;
            MatriculaAtiva = matriculaAtiva;
            DataMatricula = dataMatricula;
        }
    }
}
