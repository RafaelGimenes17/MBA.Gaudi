using MBA.Gaudi.API.DTOs.Aulas;
using MBA.Gaudi.Cursos.Domain.Enums;

namespace MBA.Gaudi.API.DTOs.Cursos
{
    public class CursoDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Instrutor { get; set; }
        public NivelCurso Nivel { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public ConteudoProgramaticoDto? ConteudoProgramatico { get; set; }
        public IEnumerable<AulaDto> Aulas { get; set; } = new List<AulaDto>();
    }
}

