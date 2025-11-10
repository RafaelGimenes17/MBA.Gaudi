using AutoMapper;
using MBA.Gaudi.GestaoConteudo.Domain.Entities;

namespace MBA.Gaudi.GestaoConteudo.Application.AutoMapper
{
    public AutomappingProfile()
    {
        CreateMap<Curso, CursoCriarDto>().ReverseMap();
        CreateMap<Curso, CursoListarDto>();
    }    
}
