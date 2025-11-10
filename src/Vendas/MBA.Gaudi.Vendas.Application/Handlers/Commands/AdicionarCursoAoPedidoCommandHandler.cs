using MBA.Gaudi.Core.Domain.Interfaces.Notifications;
using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Core.Domain.Notifications;
using MBA.Gaudi.Cursos.Domain.Interfaces.Repositories;
using MBA.Gaudi.Vendas.Application.Commands;
using MBA.Gaudi.Vendas.Domain.Entities;
using MBA.Gaudi.Vendas.Domain.Interfaces.Repositories;
using MediatR;

namespace MBA.Gaudi.Vendas.Application.Handlers.Commands
{
    public class AdicionarCursoAoPedidoCommandHandler : IRequestHandler<AdicionarCursoAoPedidoCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly ICursoRepository _cursoRepository;
        private readonly INotificador _notificador;

        public AdicionarCursoAoPedidoCommandHandler(
            IPedidoRepository pedidoRepository,
            ICursoRepository cursoRepository,
            INotificador notificador)
        {
            _pedidoRepository = pedidoRepository;
            _cursoRepository = cursoRepository;
            _notificador = notificador;
        }

        public async Task<bool> Handle(AdicionarCursoAoPedidoCommand request, CancellationToken cancellationToken)
        {
            // Valida o comando
            if (!ValidarComando(request)) return false;

            // Busca ou cria um pedido em rascunho para o aluno
            var pedido = await _pedidoRepository.ObterPedidoRascunhoPorAlunoId(request.AlunoId);
            var pedidoExistente = pedido != null;
            if (pedido == null)
            {
                pedido = Pedido.PedidoFactory.CriarPedido(request.AlunoId);
                pedido.DefinirDataCadastro(DateTime.UtcNow);
                _pedidoRepository.Adicionar(pedido);
            }

            // Busca o curso
            var curso = await _cursoRepository.BuscarPorIdAsync(request.CursoId);
            if (curso == null)
            {
                Notificar("CursoId", $"Curso com ID {request.CursoId} não encontrado");
                return false;
            }

            if (!curso.Ativo)
            {
                Notificar("CursoId", $"Curso '{curso.Titulo}' não está ativo");
                return false;
            }

            // Cria o item do pedido
            var pedidoItem = new PedidoItem(
                curso.Id,
                curso.Titulo,
                curso.Valor
            );

            try
            {
                pedido.AdicionarItem(pedidoItem);
                if (pedidoExistente)
                {
                    _pedidoRepository.AdicionarItem(pedidoItem);
                    _pedidoRepository.Alterar(pedido);
                }
            }
            catch (InvalidOperationException ex)
            {
                Notificar("CursoId", ex.Message);
                return false;
            }

            // Salva as alterações
            try
            {
                var resultado = await _pedidoRepository.UnitOfWork.Commit();
                if (!resultado)
                {
                    Notificar("Pedido", "Erro ao adicionar curso ao pedido");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Notificar("Pedido", $"Erro ao salvar: {ex.Message}");
                return false;
            }

            request.PedidoId = pedido.Id;
            return true;
        }

        private bool ValidarComando(Command request)
        {
            if (request.IsValid()) return true;

            foreach (var error in request.ValidationResult.Errors)
            {
                Notificar(error.PropertyName, error.ErrorMessage);
            }

            return false;
        }

        private void Notificar(string campo, string mensagem)
        {
            _notificador.Handle(new Notificacao
            {
                Campo = campo,
                Mensagem = mensagem
            });
        }
    }
}

