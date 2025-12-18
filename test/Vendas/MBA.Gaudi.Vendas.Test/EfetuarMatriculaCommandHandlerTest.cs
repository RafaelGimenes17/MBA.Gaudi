using MBA.Gaudi.Core.Domain.Interfaces.Mediator;
using MBA.Gaudi.Core.Domain.Interfaces.Notifications;
using MBA.Gaudi.Core.Domain.Messages.CommonMessages.IntegrationEvents;
using MBA.Gaudi.Vendas.Application.Commands;
using MBA.Gaudi.Vendas.Application.Handlers.Commands;
using MBA.Gaudi.Vendas.Domain.Entities;
using MBA.Gaudi.Vendas.Domain.Interfaces.Repositories;
using Moq;

namespace MBA.Gaudi.Vendas.Test
{
    public class EfetuarMatriculaCommandHandlerTest
    {
        [Fact]
        public async Task Handle_DeveRetornarTrue_QuandoMatriculaEfetuadaComSucesso()
        {
            // Arrange
            var mediatorMock = new Mock<IMediatorHandler>();
            var notificadorMock = new Mock<INotificador>();
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();

            var alunoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.CriarPedido(alunoId);
            pedido.AdicionarItem(new PedidoItem(Guid.NewGuid(), "Curso Teste", 100));
            pedidoRepositoryMock.Setup(r => r.ObterPedidoRascunhoPorAlunoId(alunoId)).ReturnsAsync(pedido);
            mediatorMock.Setup(m => m.PublicarEvento(It.IsAny<EfetuarMatriculaEvent>())).Returns(Task.CompletedTask);

            var handler = new EfetuarMatriculaCommandHandler(mediatorMock.Object, notificadorMock.Object, pedidoRepositoryMock.Object);
            var command = new EfetuarMatriculaCommand(alunoId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
            pedidoRepositoryMock.Verify(r => r.ObterPedidoRascunhoPorAlunoId(alunoId), Times.Once);
            mediatorMock.Verify(m => m.PublicarEvento(It.IsAny<EfetuarMatriculaEvent>()), Times.Once);
        }

        [Fact]
        public async Task Handle_DeveRetornarFalse_QuandoPedidoNaoEncontrado()
        {
            // Arrange
            var mediatorMock = new Mock<IMediatorHandler>();
            var notificadorMock = new Mock<INotificador>();
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();

            var alunoId = Guid.NewGuid();
            pedidoRepositoryMock.Setup(r => r.ObterPedidoRascunhoPorAlunoId(alunoId)).ReturnsAsync((Pedido)null);

            var handler = new EfetuarMatriculaCommandHandler(mediatorMock.Object, notificadorMock.Object, pedidoRepositoryMock.Object);
            var command = new EfetuarMatriculaCommand(alunoId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
            notificadorMock.Verify(n => n.Handle(It.IsAny<MBA.Gaudi.Core.Domain.Notifications.Notificacao>()), Times.Once);
        }

        [Fact]
        public async Task Handle_DeveRetornarFalse_QuandoPedidoSemItens()
        {
            // Arrange
            var mediatorMock = new Mock<IMediatorHandler>();
            var notificadorMock = new Mock<INotificador>();
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();

            var alunoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.CriarPedido(alunoId); // sem itens
            pedidoRepositoryMock.Setup(r => r.ObterPedidoRascunhoPorAlunoId(alunoId)).ReturnsAsync(pedido);

            var handler = new EfetuarMatriculaCommandHandler(mediatorMock.Object, notificadorMock.Object, pedidoRepositoryMock.Object);
            var command = new EfetuarMatriculaCommand(alunoId);

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
            var mediatorMock = new Mock<IMediatorHandler>();
            var notificadorMock = new Mock<INotificador>();
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();

            var alunoId = Guid.Empty; // comando inválido
            var handler = new EfetuarMatriculaCommandHandler(mediatorMock.Object, notificadorMock.Object, pedidoRepositoryMock.Object);
            var command = new EfetuarMatriculaCommand(alunoId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
            notificadorMock.Verify(n => n.Handle(It.IsAny<MBA.Gaudi.Core.Domain.Notifications.Notificacao>()), Times.AtLeastOnce);
        }
    }
}
