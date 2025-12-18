using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using MBA.Gaudi.Vendas.Application.Handlers.Commands;
using MBA.Gaudi.Vendas.Application.Commands;
using MBA.Gaudi.Vendas.Domain.Interfaces.Repositories;
using MBA.Gaudi.Vendas.Domain.Entities;
using MBA.Gaudi.Core.Domain.Interfaces.Notifications;
using MBA.Gaudi.Core.Domain.DTOs;
using MBA.Gaudi.Core.Domain.Messages.CommonMessages.IntegrationEvents;

namespace MBA.Gaudi.Vendas.Test
{
    public class AlterarStatusPedidoPagoCommandHandlerTest
    {
        [Fact]
        public async Task Handle_DeveRetornarTrue_QuandoStatusPagoComSucesso()
        {
            // Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var notificadorMock = new Mock<INotificador>();
            var pedidoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.CriarPedido(Guid.NewGuid());
            pedido.AdicionarItem(new PedidoItem(Guid.NewGuid(), "Curso Teste", 100));
            pedidoRepositoryMock.Setup(r => r.ObterPorIdComTracking(pedidoId)).ReturnsAsync(pedido);
            pedidoRepositoryMock.Setup(r => r.UnitOfWork.Commit()).ReturnsAsync(true);

            var handler = new AlterarStatusPedidoPagoCommandHandler(pedidoRepositoryMock.Object, notificadorMock.Object);
            var command = new AlterarStatusPedidoPagoCommand(pedidoId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
            pedidoRepositoryMock.Verify(r => r.ObterPorIdComTracking(pedidoId), Times.Once);
            pedidoRepositoryMock.Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact]
        public async Task Handle_DeveRetornarFalse_QuandoPedidoNaoEncontrado()
        {
            // Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var notificadorMock = new Mock<INotificador>();
            var pedidoId = Guid.NewGuid();
            pedidoRepositoryMock.Setup(r => r.ObterPorIdComTracking(pedidoId)).ReturnsAsync((Pedido)null);

            var handler = new AlterarStatusPedidoPagoCommandHandler(pedidoRepositoryMock.Object, notificadorMock.Object);
            var command = new AlterarStatusPedidoPagoCommand(pedidoId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
            notificadorMock.Verify(n => n.Handle(It.IsAny<MBA.Gaudi.Core.Domain.Notifications.Notificacao>()), Times.Once);
        }

        [Fact]
        public async Task Handle_DeveRetornarFalse_QuandoPedidoNaoPodeSerPago()
        {
            // Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var notificadorMock = new Mock<INotificador>();
            var pedidoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.CriarPedido(Guid.NewGuid());
            // Não adiciona itens, não pode ser pago
            pedidoRepositoryMock.Setup(r => r.ObterPorIdComTracking(pedidoId)).ReturnsAsync(pedido);

            var handler = new AlterarStatusPedidoPagoCommandHandler(pedidoRepositoryMock.Object, notificadorMock.Object);
            var command = new AlterarStatusPedidoPagoCommand(pedidoId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
            notificadorMock.Verify(n => n.Handle(It.IsAny<MBA.Gaudi.Core.Domain.Notifications.Notificacao>()), Times.Once);
        }

        [Fact]
        public async Task Handle_DeveRetornarFalse_QuandoComandoInvalido()
        {
            // Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var notificadorMock = new Mock<INotificador>();
            var pedidoId = Guid.Empty; // comando inválido

            var handler = new AlterarStatusPedidoPagoCommandHandler(pedidoRepositoryMock.Object, notificadorMock.Object);
            var command = new AlterarStatusPedidoPagoCommand(pedidoId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
            notificadorMock.Verify(n => n.Handle(It.IsAny<MBA.Gaudi.Core.Domain.Notifications.Notificacao>()), Times.AtLeastOnce);
        }
    }
}
