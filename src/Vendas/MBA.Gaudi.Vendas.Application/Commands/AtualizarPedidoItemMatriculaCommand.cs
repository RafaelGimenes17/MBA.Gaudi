using MBA.Gaudi.Core.Domain.DTOs;
using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Vendas.Application.Validators;

namespace MBA.Gaudi.Vendas.Application.Commands
{
    public class AtualizarPedidoItemMatriculaCommand : Command
    {
        public Guid PedidoId { get; set; }
        public List<MatriculaItemDto> Matriculas { get; set; }

        public AtualizarPedidoItemMatriculaCommand(Guid pedidoId, List<MatriculaItemDto> matriculas)
        {
            PedidoId = pedidoId;
            Matriculas = matriculas ?? new List<MatriculaItemDto>();
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarPedidoItemMatriculaCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
