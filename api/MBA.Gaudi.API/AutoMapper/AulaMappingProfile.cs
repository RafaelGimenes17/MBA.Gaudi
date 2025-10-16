using AutoMapper;
using MBA.Gaudi.API.DTOs.Alunos;
using MBA.Gaudi.Cursos.Domain.Entities;

namespace MBA.Gaudi.API.AutoMapper
{
    public class AulaMappingProfile : Profile
    {
        public AulaMappingProfile()
        {
            // Mapeamento de Aula para AulaCursoDto
            CreateMap<Aula, AulaCursoDto>()
                .ForMember(dest => dest.Ativo, opt => opt.MapFrom(src => src.Ativa));
        }
    }
}

