using MeuBackEndApi.Src.Models;

namespace MeuBackEndApi.Src.Interfaces
{
    public interface ILoginRepository
    {
        Usuario BuscarPorUsuario(string usuarioLogin);
    }
}
