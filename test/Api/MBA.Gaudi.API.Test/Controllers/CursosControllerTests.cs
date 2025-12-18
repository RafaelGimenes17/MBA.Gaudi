using AutoMapper;
using MBA.Gaudi.API.Controllers;
using MBA.Gaudi.API.DTOs.Cursos;
using MBA.Gaudi.Core.Domain.Interfaces.Identity;
using MBA.Gaudi.Core.Domain.Interfaces.Mediator;
using MBA.Gaudi.Core.Domain.Interfaces.Notifications;
using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Cursos.Domain.Entities;
using MBA.Gaudi.Cursos.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class CursosControllerTests
{
    private readonly Mock<IMediatorHandler> _mediatorHandlerMock = new();
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly Mock<INotificador> _notificadorMock = new();
    private readonly Mock<IUser> _userMock = new();

    private CursosController CreateController()
    {
        return new CursosController(
            _mediatorHandlerMock.Object,
            _mapperMock.Object,
            _notificadorMock.Object,
            _userMock.Object
        );
    }

    //[Fact]
    //public async Task Criar_DeveRetornarBadRequest_QuandoModelStateInvalido()
    //{
    //    var controller = CreateController();
    //    controller.ModelState.AddModelError("Titulo", "Obrigatório");
    //    var result = await controller.Criar(new CriarCursoDto());
    //    Assert.IsType<ObjectResult>(result);
    //}

    [Fact]
    public async Task Criar_DeveRetornarCreated_QuandoSucesso()
    {
        var controller = CreateController();
        _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<Command>())).ReturnsAsync(true);

        var dto = new CriarCursoDto { Titulo = "Curso", Descricao = "Desc", Instrutor = "Instrutor", Nivel = NivelCurso.Basico, Valor = 100 };
        var result = await controller.Criar(dto);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(201, createdResult.StatusCode);
    }

    //[Fact]
    //public async Task Atualizar_DeveRetornarBadRequest_QuandoModelStateInvalido()
    //{
    //    var controller = CreateController();
    //    controller.ModelState.AddModelError("Titulo", "Obrigatório");
    //    var result = await controller.Atualizar(Guid.NewGuid(), new AtualizarCursoDto());
    //    Assert.IsType<ObjectResult>(result);
    //}

    //[Fact]
    //public async Task Atualizar_DeveRetornarOk_QuandoSucesso()
    //{
    //    var controller = CreateController();
    //    _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<Command>())).ReturnsAsync(true);

    //    var dto = new AtualizarCursoDto { Titulo = "Curso", Descricao = "Desc", Nivel = NivelCurso.Basico };
    //    var result = await controller.Atualizar(Guid.NewGuid(), dto);

    //    var okResult = Assert.IsType<ObjectResult>(result);
    //    Assert.Equal(200, okResult.StatusCode);
    //}

    //[Fact]
    //public async Task ObterPorId_DeveRetornarNotFound_QuandoCursoNaoExiste()
    //{
    //    var controller = CreateController();
    //    _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<object>())).ReturnsAsync((object)null);

    //    var result = await controller.ObterPorId(Guid.NewGuid());
    //    Assert.IsType<NotFoundResult>(result);
    //}

    //[Fact]
    //public async Task ObterPorId_DeveRetornarOk_QuandoCursoExiste()
    //{
    //    var controller = CreateController();
    //    var curso = new { Id = Guid.NewGuid() };
    //    _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<object>())).ReturnsAsync(curso);
    //    _mapperMock.Setup(m => m.Map<CursoDto>(It.IsAny<object>())).Returns(new CursoDto());

    //    var result = await controller.ObterPorId(Guid.NewGuid());
    //    var okResult = Assert.IsType<ObjectResult>(result);
    //    Assert.Equal(200, okResult.StatusCode);
    //}

    //[Fact]
    //public async Task ListarCursosAtivos_DeveRetornarOk()
    //{
    //    var controller = CreateController();
    //    _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<object>())).ReturnsAsync(new List<object>());
    //    _mapperMock.Setup(m => m.Map<IEnumerable<CursoDto>>(It.IsAny<object>())).Returns(new List<CursoDto>());

    //    var result = await controller.ListarCursosAtivos();
    //    var okResult = Assert.IsType<ObjectResult>(result);
    //    Assert.Equal(200, okResult.StatusCode);
    //}

    //[Fact]
    //public async Task Listar_DeveRetornarOk()
    //{
    //    var controller = CreateController();
    //    _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<object>())).ReturnsAsync(new List<object>());
    //    _mapperMock.Setup(m => m.Map<IEnumerable<CursoDto>>(It.IsAny<Command>())).Returns(new List<CursoDto>());

    //    var result = await controller.Listar();
    //    var okResult = Assert.IsType<ObjectResult>(result);
    //    Assert.Equal(200, okResult.StatusCode);
    //}

    //[Fact]
    //public async Task Deletar_DeveRetornarOk_QuandoSucesso()
    //{
    //    var controller = CreateController();
    //    _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<Command>())).ReturnsAsync(true);

    //    var result = await controller.Deletar(Guid.NewGuid());
    //    var okResult = Assert.IsType<ObjectResult>(result);
    //    Assert.Equal(200, okResult.StatusCode);
    //}

    //[Fact]
    //public async Task Deletar_DeveRetornarBadRequest_QuandoFalha()
    //{
    //    var controller = CreateController();
    //    _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<Command>())).ReturnsAsync(false);

    //    var result = await controller.Deletar(Guid.NewGuid());
    //    Assert.IsType<ObjectResult>(result);
    //}

    //[Fact]
    //public async Task Ativar_DeveRetornarOk_QuandoSucesso()
    //{
    //    var controller = CreateController();
    //    _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<Command>())).ReturnsAsync(true);

    //    var result = await controller.Ativar(Guid.NewGuid());
    //    var okResult = Assert.IsType<ObjectResult>(result);
    //    Assert.Equal(200, okResult.StatusCode);
    //}

    //[Fact]
    //public async Task Inativar_DeveRetornarOk_QuandoSucesso()
    //{
    //    var controller = CreateController();
    //    _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<Command>())).ReturnsAsync(true);

    //    var result = await controller.Inativar(Guid.NewGuid());
    //    var okResult = Assert.IsType<ObjectResult>(result);
    //    Assert.Equal(200, okResult.StatusCode);
    //}
}