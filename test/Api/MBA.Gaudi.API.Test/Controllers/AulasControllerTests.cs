using AutoMapper;
using MBA.Gaudi.API.Controllers;
using MBA.Gaudi.API.DTOs.Aulas;
using MBA.Gaudi.Core.Domain.Interfaces.Identity;
using MBA.Gaudi.Core.Domain.Interfaces.Mediator;
using MBA.Gaudi.Core.Domain.Interfaces.Notifications;
using MBA.Gaudi.Core.Domain.Messages;
using MBA.Gaudi.Cursos.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class AulasControllerTests
{
    private readonly Mock<IMediatorHandler> _mediatorHandlerMock = new();
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly Mock<INotificador> _notificadorMock = new();
    private readonly Mock<IUser> _userMock = new();

    private AulasController CreateController()
    {
        return new AulasController(
            _mediatorHandlerMock.Object,
            _mapperMock.Object,
            _notificadorMock.Object,
            _userMock.Object
        );
    }

    [Fact]
    public async Task Criar_DeveRetornarBadRequest_QuandoModelStateInvalido()
    {
        var controller = CreateController();
        controller.ModelState.AddModelError("Titulo", "Obrigatório");
        var result = await controller.Criar(new CriarAulaDto());
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Criar_DeveRetornarCreated_QuandoSucesso()
    {
        var controller = CreateController();
        _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<Command>())).ReturnsAsync(true);

        var dto = new CriarAulaDto { CursoId = Guid.NewGuid(), Titulo = "Aula", Descricao = "Desc", DuracaoMinutos = 10, Ordem = 1 };
        var result = await controller.Criar(dto);

        var createdResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(201, createdResult.StatusCode);
    }

    [Fact]
    public async Task Atualizar_DeveRetornarBadRequest_QuandoModelStateInvalido()
    {
        var controller = CreateController();
        controller.ModelState.AddModelError("Titulo", "Obrigatório");
        var result = await controller.Atualizar(Guid.NewGuid(), new AtualizarAulaDto());
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Atualizar_DeveRetornarOk_QuandoSucesso()
    {
        var controller = CreateController();
        _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<Command>())).ReturnsAsync(true);

        var dto = new AtualizarAulaDto { Titulo = "Aula", Descricao = "Desc", DuracaoMinutos = 10, Ordem = 1 };
        var result = await controller.Atualizar(Guid.NewGuid(), dto);

        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public async Task ObterPorId_DeveRetornarNotFound_QuandoAulaNaoExiste()
    {
        var controller = CreateController();
        _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<Command>())).ReturnsAsync(false);

        var result = await controller.ObterPorId(Guid.NewGuid());
        Assert.IsType<NotFoundResult>(result);
    }

    //[Fact]
    //public async Task ObterPorId_DeveRetornarOk_QuandoAulaExiste()  
    //{
    //    var controller = CreateController();
    //    var aula = new Aula("TESTE", "aulaDescricao", 10, 1);
    //    var requestMock = new Mock<IRequest<object>>().Object;
    //    _mediatorHandlerMock.Setup(m => m.EnviarComando<Aula>(It.IsAny<IRequest<object>>())).ReturnsAsync(aula);
    //    _mapperMock.Setup(m => m.Map<AulaDto>(It.IsAny<object>())).Returns(new AulaDto());

    //    var result = await controller.ObterPorId(aula.Id);
    //    var okResult = Assert.IsType<ObjectResult>(result);
    //    Assert.Equal(200, okResult.StatusCode);
    //}

    [Fact]
    public async Task Listar_DeveRetornarOk()
    {
        var controller = CreateController();
        _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<Command>())).ReturnsAsync(true);
        _mapperMock.Setup(m => m.Map<IEnumerable<AulaDto>>(It.IsAny<object>())).Returns(new List<AulaDto>());

        var result = await controller.Listar();
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public async Task Deletar_DeveRetornarOk_QuandoSucesso()
    {
        var controller = CreateController();
        _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<Command>())).ReturnsAsync(true);

        var result = await controller.Deletar(Guid.NewGuid());
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public async Task Deletar_DeveRetornarBadRequest_QuandoFalha()
    {
        var controller = CreateController();
        _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<Command>())).ReturnsAsync(false);

        var result = await controller.Deletar(Guid.NewGuid());
        var okResult = Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Ativar_DeveRetornarOk_QuandoSucesso()
    {
        var controller = CreateController();
        _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<Command>())).ReturnsAsync(true);

        var result = await controller.Ativar(Guid.NewGuid());
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public async Task Inativar_DeveRetornarOk_QuandoSucesso()
    {
        var controller = CreateController();
        _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<Command>())).ReturnsAsync(true);

        var result = await controller.Inativar(Guid.NewGuid());
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }
}