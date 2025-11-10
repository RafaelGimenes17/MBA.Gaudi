using AutoMapper;
using MBA.Gaudi.GestaoConteudo.Domain.DTOs.Cursos;
using MBA.Gaudi.GestaoConteudo.Domain.Entities;
using MBA.Gaudi.GestaoConteudo.Domain.Interfaces.Repositories;
using MBA.Gaudi.GestaoConteudo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MBA.Gaudi.GestaoConteudo.Application.Services.Cursos
{
    public class CursoAppService : ICursoAppService
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMapper _mapper;
        private readonly ICursoService _cursoService;

        public CursoAppService(ICursoRepository cursoRepository,
                               IMapper mapper,
                               ICursoService cursoService)
        {
            _cursoRepository = cursoRepository;
            _mapper = mapper;
            _cursoService = cursoService;
        }

        public async Task<CursoListarDto> ObterPorId(Guid id)
        {
            var curso = await _cursoRepository.BuscarPorIdAsync(id);
            var _curso = _mapper.Map<CursoListarDto>(curso);
            return _curso;
        }

        public Task<IEnumerable<CursoListarDto>> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public async Task Adicionar(CursoCriarDto cursoDto)
        {
            var curso = _mapper.Map<Curso>(cursoDto);
            _cursoRepository.Adicionar(curso);
            await _cursoService.VerificarAulas(Guid.Empty, new Aula(String.Empty, String.Empty, 0, 0));
            await _cursoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _cursoRepository?.Dispose();
            _cursoService?.Dispose();
        }
    }
}
