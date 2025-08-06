using AutoMapper;
using MeuBackEndApi.Src.Models;
using MeuBackEndApi.Src.Views;
using MeuBackEndApi.Src.Views.comanda;

namespace MeuBackEndApi.Src.Mappers
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoView>().ReverseMap();
        }
    }
}