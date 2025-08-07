using AutoMapper;
using MeuBackEndApi.Src.Models;
using MeuBackEndApi.Src.Views;
using MeuBackEndApi.Src.Views.comanda;

namespace MeuBackEndApi.Src.Mappers
{
    public class ComandaProfile : Profile
    {
        public ComandaProfile()
        {
            CreateMap<ComandaUsuarioView, Comanda>().ReverseMap();

            CreateMap<Comanda, ComandaCriadaView>()
                .ForMember(dest => dest.Produtos, opt => opt.MapFrom(src => src.Produtos));

            CreateMap<Comanda, ComandaCompletaView>()
                .ForMember(dest => dest.Produtos, opt => opt.MapFrom(src => src.Produtos));

            CreateMap<Produto, ProdutoView>().ReverseMap();
        }
    }
}