using AutoMapper;
using MeuBackEndApi.Src.Models;
using MeuBackEndApi.Src.Views;

namespace MeuBackEndApi.Src.Mappers
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioView, Usuario>()
                .ConstructUsing(view => new Usuario(view.Id, view.Usuario, view.Nome, view.Email, view.Senha, view.Telefone))
                .ForMember(dest => dest.Senha, opt => opt.Ignore());

            CreateMap<Usuario, UsuarioView>()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.UsuarioLogin));
        }
    }
}