using System;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Xunit;
using MBA.Gaudi.Vendas.Application.Handlers.Commands;
using MBA.Gaudi.Vendas.Application.Commands;
using MBA.Gaudi.Vendas.Domain.Interfaces.Repositories;
using MBA.Gaudi.Vendas.Domain.Entities;

namespace MBA.Gaudi.Vendas.Test
{
    public class PedidoCommandHandlerTest
    {
        [Fact]
        public async Task Handle_DeveRetornarTrue_QuandoCursoAdicionadoAoPedidoComSucesso()
        {
            // Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var alunoId = Guid.NewGuid();
            var cursoId = Guid.NewGuid();
            var valor = 100m; // Defina um valor decimal adequado para o curso
            var pedido = Pedido.PedidoFactory.CriarPedido(alunoId);
            pedidoRepositoryMock.Setup(r => r.ObterPedidoRascunhoPorAlunoId(alunoId)).ReturnsAsync(pedido);
            pedidoRepositoryMock.Setup(r => r.UnitOfWork.Commit()).ReturnsAsync(true);

            var command = new AdicionarCursoPedidoItemCommand(alunoId, valor);
            var handler = new PedidoCommandHandler(pedidoRepositoryMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
            pedidoRepositoryMock.Verify(r => r.ObterPedidoRascunhoPorAlunoId(alunoId), Times.Once);
            pedidoRepositoryMock.Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact]
        public async Task Handle_DeveRetornarTrue_QuandoPedidoCriadoComSucesso()
        {
            // Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var alunoId = Guid.NewGuid();
            var cursoId = Guid.NewGuid();
            var valor = 100m; // Defina um valor decimal adequado para o curso
            pedidoRepositoryMock.Setup(r => r.ObterPedidoRascunhoPorAlunoId(alunoId)).ReturnsAsync((Pedido)null);
            pedidoRepositoryMock.Setup(r => r.UnitOfWork.Commit()).ReturnsAsync(true);

            var command = new AdicionarCursoPedidoItemCommand(alunoId, valor);
            var handler = new PedidoCommandHandler(pedidoRepositoryMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
            pedidoRepositoryMock.Verify(r => r.Adicionar(It.IsAny<Pedido>()), Times.Once);
            pedidoRepositoryMock.Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact]
        public async Task Handle_DeveRetornarFalse_QuandoComandoInvalido()
        {
            // Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var valor = 100m;
            var command = new AdicionarCursoPedidoItemCommand(Guid.Empty, valor); // comando inválido
            var handler = new PedidoCommandHandler(pedidoRepositoryMock.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
        }
    }
}
