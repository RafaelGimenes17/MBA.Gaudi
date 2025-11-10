using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.Core.DTOs
{
    public class MatriculaItemDto
    {
        public Guid CursoId { get; set; }
        public Guid MatriculaId { get; set; }

        public MatriculaItemDto() { }

        public MatriculaItemDto(Guid cursoId, Guid matriculaId)
        {
            CursoId = cursoId;
            MatriculaId = matriculaId;
        }
    }
}
