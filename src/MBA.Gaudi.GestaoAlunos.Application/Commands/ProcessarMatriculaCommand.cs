using MBA.Gaudi.GestaoAlunos.Application.Validators;

using MBA.Gaudi.Core.DTOs;
using MBA.Gaudi.Core.Messages;


namespace MBA.Gaudi.GestaoAlunos.Application.Commands
{
    public class ProcessarMatriculaCommand : Command
    {
        public Guid AlunoId { get; private set; }
        public Guid PedidoId { get; private set; }
        public ListaCursosPedidoDto ListaCursos { get; private set; }

        public ProcessarMatriculaCommand(Guid alunoId, Guid pedidoId, ListaCursosPedidoDto listaCursos)
        {
            AggregateId = alunoId;
            AlunoId = alunoId;
            PedidoId = pedidoId;
            ListaCursos = listaCursos;
        }

        public override bool IsValid()
        {
            ValidationResult = new ProcessarMatriculaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
