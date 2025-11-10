using AutoMapper;
using MBA.Gaudi.API.DTOs.Pedido;
using MBA.Gaudi.Vendas.Domain.Entities;

namespace MBA.Gaudi.API.AutoMapper
{
    public class PedidoMappingProfile : Profile
    {
        public PedidoMappingProfile()
        {
            // Mapeamento de Pedido para PedidoRascunhoDto
            CreateMap<Pedido, PedidoRascunhoDto>()
                .ForMember(dest => dest.QuantidadeCursos, opt => opt.MapFrom(src => src.PedidoItens.Count))
                .ForMember(dest => dest.Itens, opt => opt.MapFrom(src => src.PedidoItens));

            // Mapeamento de PedidoItem para PedidoItemDto
            CreateMap<PedidoItem, PedidoItemDto>();
        }
    }
}

