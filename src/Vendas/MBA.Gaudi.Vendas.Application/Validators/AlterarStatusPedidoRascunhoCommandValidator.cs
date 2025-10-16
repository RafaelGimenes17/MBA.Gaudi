using FluentValidation;
using MBA.Gaudi.Vendas.Application.Commands;

namespace MBA.Gaudi.Vendas.Application.Validators
{
    public class AlterarStatusPedidoRascunhoCommandValidator : AbstractValidator<AlterarStatusPedidoRascunhoCommand>
    {
        public AlterarStatusPedidoRascunhoCommandValidator()
        {
            RuleFor(c => c.PedidoId)
                .NotEmpty()
                .WithMessage("O código do pedido é inválido.")
                .NotEqual(Guid.Empty)
                .WithMessage("O código do pedido é inválido.");
        }
    }
}
