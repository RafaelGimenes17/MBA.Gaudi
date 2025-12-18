using MBA.Gaudi.Core.Domain.Interfaces.Notifications;
using MBA.Gaudi.Cursos.Domain.Entities;
using MBA.Gaudi.Cursos.Domain.Interfaces.Repositories;
using MBA.Gaudi.Vendas.Application.Commands;
using MBA.Gaudi.Vendas.Application.Handlers.Commands;
using MBA.Gaudi.Vendas.Domain.Entities;
using MBA.Gaudi.Vendas.Domain.Interfaces.Repositories;
using Moq;

namespace MBA.Gaudi.Vendas.Test
{
    public class AdicionarCursoAoPedidoCommandHandlerTest
    {
        [Fact]
        public async Task Handle_DeveRetornarTrue_QuandoCursoAdicionadoComSucesso()
        {
            // Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var cursoRepositoryMock = new Mock<ICursoRepository>();
            var notificadorMock = new Mock<INotificador>();

            var alunoId = Guid.NewGuid();
            var cursoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.CriarPedido(alunoId);
            var curso = new Curso("Curso Teste", "Descricao Teste", "Instrutor Teste", MBA.Gaudi.Cursos.Domain.Enums.NivelCurso.Basico, 100);

            pedidoRepositoryMock.Setup(r => r.ObterPedidoRascunhoPorAlunoId(alunoId)).ReturnsAsync(pedido);
            cursoRepositoryMock.Setup(r => r.BuscarPorIdAsync(cursoId)).ReturnsAsync(curso);
            pedidoRepositoryMock.Setup(r => r.UnitOfWork.Commit()).ReturnsAsync(true);

            var handler = new AdicionarCursoAoPedidoCommandHandler(
                pedidoRepositoryMock.Object,
                cursoRepositoryMock.Object,
                notificadorMock.Object
            );
            var command = new AdicionarCursoAoPedidoCommand(alunoId, cursoId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result);
            pedidoRepositoryMock.Verify(r => r.ObterPedidoRascunhoPorAlunoId(alunoId), Times.Once);
            cursoRepositoryMock.Verify(r => r.BuscarPorIdAsync(cursoId), Times.Once);
            pedidoRepositoryMock.Verify(r => r.UnitOfWork.Commit(), Times.Once);
        }

        [Fact]
        public async Task Handle_DeveRetornarFalse_QuandoCursoNaoExiste()
        {
            // Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var cursoRepositoryMock = new Mock<ICursoRepository>();
            var notificadorMock = new Mock<INotificador>();

            var alunoId = Guid.NewGuid();
            var cursoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.CriarPedido(alunoId);

            pedidoRepositoryMock.Setup(r => r.ObterPedidoRascunhoPorAlunoId(alunoId)).ReturnsAsync(pedido);
            cursoRepositoryMock.Setup(r => r.BuscarPorIdAsync(cursoId)).ReturnsAsync((Curso)null);

            var handler = new AdicionarCursoAoPedidoCommandHandler(
                pedidoRepositoryMock.Object,
                cursoRepositoryMock.Object,
                notificadorMock.Object
            );
            var command = new AdicionarCursoAoPedidoCommand(alunoId, cursoId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
            notificadorMock.Verify(n => n.Handle(It.IsAny<MBA.Gaudi.Core.Domain.Notifications.Notificacao>()), Times.Once);
        }

        [Fact]
        public async Task Handle_DeveRetornarFalse_QuandoCursoInativo()
        {
            // Arrange
            var pedidoRepositoryMock = new Mock<IPedidoRepository>();
            var cursoRepositoryMock = new Mock<ICursoRepository>();
            var notificadorMock = new Mock<INotificador>();

            var alunoId = Guid.NewGuid();
            var cursoId = Guid.NewGuid();
            var pedido = Pedido.PedidoFactory.CriarPedido(alunoId);
            var curso = new Curso("Curso Teste", "Descricao Teste", "Instrutor Teste", MBA.Gaudi.Cursos.Domain.Enums.NivelCurso.Basico, 100);
            curso.Inativar();

            pedidoRepositoryMock.Setup(r => r.ObterPedidoRascunhoPorAlunoId(alunoId)).ReturnsAsync(pedido);
            cursoRepositoryMock.Setup(r => r.BuscarPorIdAsync(cursoId)).ReturnsAsync(curso);

            var handler = new AdicionarCursoAoPedidoCommandHandler(
                pedidoRepositoryMock.Object,
                cursoRepositoryMock.Object,
                notificadorMock.Object
            );
            var command = new AdicionarCursoAoPedidoCommand(alunoId, cursoId);

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
            var cursoRepositoryMock = new Mock<ICursoRepository>();
            var notificadorMock = new Mock<INotificador>();

            var alunoId = Guid.Empty; // comando inválido
            var cursoId = Guid.NewGuid();

            var handler = new AdicionarCursoAoPedidoCommandHandler(
                pedidoRepositoryMock.Object,
                cursoRepositoryMock.Object,
                notificadorMock.Object
            );
            var command = new AdicionarCursoAoPedidoCommand(alunoId, cursoId);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result);
            notificadorMock.Verify(n => n.Handle(It.IsAny<MBA.Gaudi.Core.Domain.Notifications.Notificacao>()), Times.AtLeastOnce);
        }
    }
}
