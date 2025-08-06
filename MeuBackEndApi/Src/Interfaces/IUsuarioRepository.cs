using MeuBackEndApi.Src.Models;

namespace MeuBackEndApi.Src.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> Listar();
        Task<Usuario> BuscarPorId(int id);
        Task Cadastrar(Usuario usuario);
    }
}
