using System;
using System.Collections.Generic;
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

namespace MBA.Gaudi.Vendas.Test
{
    public class AtualizarPedidoItemMatriculaCommandHandlerTest
    {
        [Fact]
        public async Task Handle_DeveRetornarTrue_QuandoItensAtualizadosComSucesso()
        {
            // Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var notificadorMock = new Mock<INotificador>();
            var pedidoId = Guid.NewGuid();
            var cursoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.CriarPedido(Guid.NewGuid());
            var pedidoItem = new PedidoItem(cursoId, "Curso Teste", 100);
            pedido.AdicionarItem(pedidoItem);

            pedidoRepositoryMock.Setup(r => r.ObterPorIdComTracking(pedidoId)).ReturnsAsync(pedido);
            pedidoRepositoryMock.Setup(r => r.UnitOfWork.Commit()).ReturnsAsync(true);

            var matriculas = new List<MatriculaItemDto>
            {
                new MatriculaItemDto { CursoId = cursoId, MatriculaId = Guid.NewGuid() }
            };
            var command = new AtualizarPedidoItemMatriculaCommand(pedidoId, matriculas);
            var handler = new AtualizarPedidoItemMatriculaCommandHandler(pedidoRepositoryMock.Object, notificadorMock.Object);

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

            var command = new AtualizarPedidoItemMatriculaCommand(pedidoId, new List<MatriculaItemDto>());
            var handler = new AtualizarPedidoItemMatriculaCommandHandler(pedidoRepositoryMock.Object, notificadorMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
            notificadorMock.Verify(n => n.Handle(It.IsAny<MBA.Gaudi.Core.Domain.Notifications.Notificacao>()), Times.Once);
        }

        [Fact]
        public async Task Handle_DeveRetornarFalse_QuandoNenhumItemAtualizado()
        {
            // Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var notificadorMock = new Mock<INotificador>();
            var pedidoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.CriarPedido(Guid.NewGuid());
            pedidoRepositoryMock.Setup(r => r.ObterPorIdComTracking(pedidoId)).ReturnsAsync(pedido);
            pedidoRepositoryMock.Setup(r => r.UnitOfWork.Commit()).ReturnsAsync(true);

            var matriculas = new List<MatriculaItemDto>
            {
                new MatriculaItemDto { CursoId = Guid.NewGuid(), MatriculaId = Guid.NewGuid() }
            };
            var command = new AtualizarPedidoItemMatriculaCommand(pedidoId, matriculas);
            var handler = new AtualizarPedidoItemMatriculaCommandHandler(pedidoRepositoryMock.Object, notificadorMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
            notificadorMock.Verify(n => n.Handle(It.IsAny<MBA.Gaudi.Core.Domain.Notifications.Notificacao>()), Times.AtLeastOnce);
        }

        [Fact]
        public async Task Handle_DeveRetornarFalse_QuandoComandoInvalido()
        {
            // Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var notificadorMock = new Mock<INotificador>();
            var pedidoId = Guid.Empty; // comando inválido
            var command = new AtualizarPedidoItemMatriculaCommand(pedidoId, new List<MatriculaItemDto>());
            var handler = new AtualizarPedidoItemMatriculaCommandHandler(pedidoRepositoryMock.Object, notificadorMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
            notificadorMock.Verify(n => n.Handle(It.IsAny<MBA.Gaudi.Core.Domain.Notifications.Notificacao>()), Times.AtLeastOnce);
        }
    }
}
