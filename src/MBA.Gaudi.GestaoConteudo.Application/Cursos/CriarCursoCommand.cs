using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Cursos
{
    public class CriarCursoCommand : Command
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Instrutor { get; set; }
        public NivelCurso Nivel { get; set; }
        public decimal Valor { get; set; }
        public ConteudoProgramaticoCommand? ConteudoProgramatico { get; set; }

        public CriarCursoCommand(string titulo, string descricao, string instrutor, NivelCurso nivel, decimal valor, ConteudoProgramaticoCommand? conteudoProgramatico = null)
        {
            Titulo = titulo;
            Descricao = descricao;
            Instrutor = instrutor;
            Nivel = nivel;
            Valor = valor;
            ConteudoProgramatico = conteudoProgramatico;
        }

        public override bool IsValid()
        {
            ValidationResult = new CriarCursoCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }

        public void SetAggregateId(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
