using AutoMapper;
using MBA.Gaudi.Alunos.Application.Queries;
using MBA.Gaudi.Alunos.Domain.Interfaces.Repositories;
using MBA.Gaudi.Alunos.Domain.Interfaces.Services;
using MBA.Gaudi.API.Controllers;
using MBA.Gaudi.API.DTOs.Alunos;
using MBA.Gaudi.Core.Domain.Interfaces.Identity;
using MBA.Gaudi.Core.Domain.Interfaces.Mediator;
using MBA.Gaudi.Core.Domain.Interfaces.Notifications;
using MBA.Gaudi.Cursos.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class AlunosControllerTests
{
    private readonly Mock<IMediatorHandler> _mediatorHandlerMock = new();
    private readonly Mock<ICursoRepository> _cursoRepositoryMock = new();
    private readonly Mock<ICertificadoRepository> _certificadoRepositoryMock = new();
    private readonly Mock<IAlunoRepository> _alunoRepositoryMock = new();
    private readonly Mock<ICertificadoPdfService> _certificadoPdfServiceMock = new();
    private readonly Mock<IMapper> _mapperMock = new();
    private readonly Mock<INotificador> _notificadorMock = new();
    private readonly Mock<IUser> _userMock = new();

    private AlunosController CreateController(bool usuarioAutenticado = true, Guid? usuarioId = null)
    {
        _userMock.Setup(u => u.IsAuthenticated()).Returns(usuarioAutenticado);
        _userMock.Setup(u => u.GetUserId()).Returns(usuarioId ?? Guid.NewGuid());
        return new AlunosController(
            _mediatorHandlerMock.Object,
            _notificadorMock.Object,
            _userMock.Object,
            _cursoRepositoryMock.Object,
            _certificadoRepositoryMock.Object,
            _alunoRepositoryMock.Object,
            _certificadoPdfServiceMock.Object,
            _mapperMock.Object
        );
    }

    [Fact]
    public async Task ObterMeusCursos_DeveRetornarUnauthorized_QuandoUsuarioNaoAutenticado()
    {
        var controller = CreateController(usuarioAutenticado: false);
        var result = await controller.ObterMeusCursos();
        Assert.IsType<UnauthorizedResult>(result);
    }

    //[Fact]
    //public async Task ObterMeusCursos_DeveRetornarCursosMatriculados_QuandoExistemMatriculas()
    //{
    //    var controller = CreateController();
    //    var alunoId = Guid.NewGuid();
    //    _userMock.Setup(u => u.GetUserId()).Returns(alunoId);

    //    var query = new ObterCursosMatriculadosQuery(alunoId);

    //    var True = new List<dynamic> { new { Id = Guid.NewGuid(), CursoId = Guid.NewGuid(), DataMatricula = DateTime.Now, DataValidade = DateTime.Now.AddMonths(1), Ativo = true, EstaVencida = () => false, ObterDiasRestantes = () => 30, ObterProgressoGeral = () => 100 } };


    //    _mediatorHandlerMock.Setup(m => m.EnviarComando(It.IsAny<ObterCursosMatriculadosQuery>())).ReturnsAsync(true);

    //    _cursoRepositoryMock.Setup(c => c.BuscarPorIdAsync(It.IsAny<Guid>())).ReturnsAsync(new { Titulo = "Curso Teste" });

    //    var result = await controller.ObterMeusCursos();
    //    var okResult = Assert.IsType<ObjectResult>(result);
    //    Assert.Equal(200, okResult.StatusCode);
    //}

    [Fact]
    public async Task ObterAulasPorCurso_DeveRetornarUnauthorized_QuandoUsuarioNaoAutenticado()
    {
        var controller = CreateController(usuarioAutenticado: false);
        var result = await controller.ObterAulasPorCurso(Guid.NewGuid());
        Assert.IsType<UnauthorizedResult>(result);
    }

    [Fact]
    public async Task AcessarEstudoAula_DeveRetornarUnauthorized_QuandoUsuarioNaoAutenticado()
    {
        var controller = CreateController(usuarioAutenticado: false);
        var result = await controller.AcessarEstudoAula(new AcessarEstudoDto());
        Assert.IsType<UnauthorizedResult>(result);
    }

    [Fact]
    public async Task IniciarEstudoAula_DeveRetornarUnauthorized_QuandoUsuarioNaoAutenticado()
    {
        var controller = CreateController(usuarioAutenticado: false);
        var result = await controller.IniciarEstudoAula(new IniciarEstudoDto());
        Assert.IsType<UnauthorizedResult>(result);
    }

    [Fact]
    public async Task FinalizarEstudoAula_DeveRetornarUnauthorized_QuandoUsuarioNaoAutenticado()
    {
        var controller = CreateController(usuarioAutenticado: false);
        var result = await controller.FinalizarEstudoAula(new FinalizarEstudoDto());
        Assert.IsType<UnauthorizedResult>(result);
    }

    [Fact]
    public async Task SolicitarCertificado_DeveRetornarUnauthorized_QuandoUsuarioNaoAutenticado()
    {
        var controller = CreateController(usuarioAutenticado: false);
        var result = await controller.SolicitarCertificado(new SolicitarCertificadoDto());
        Assert.IsType<UnauthorizedResult>(result);
    }

    [Fact]
    public async Task ListarCertificados_DeveRetornarUnauthorized_QuandoUsuarioNaoAutenticado()
    {
        var controller = CreateController(usuarioAutenticado: false);
        var result = await controller.ListarCertificados();
        Assert.IsType<UnauthorizedResult>(result);
    }

    [Fact]
    public async Task VisualizarCertificado_DeveRetornarUnauthorized_QuandoUsuarioNaoAutenticado()
    {
        var controller = CreateController(usuarioAutenticado: false);
        var result = await controller.VisualizarCertificado(Guid.NewGuid());
        Assert.IsType<UnauthorizedResult>(result);
    }
}