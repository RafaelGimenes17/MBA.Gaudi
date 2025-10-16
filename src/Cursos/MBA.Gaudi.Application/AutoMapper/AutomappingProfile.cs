using AutoMapper;
using MBA.Gaudi.Cursos.Domain.DTOs.Cursos;
using MBA.Gaudi.Pagamentos.Domain.Entities;

namespace MBA.Gaudi.Cursos.Application.AutoMapper
{
    public class AutomappingProfile : Profile
    {
        public AutomappingProfile()
        {
            CreateMap<Curso, CursoCriarDto>().ReverseMap();
            CreateMap<Curso, CursoListarDto>();
        }
    }
}