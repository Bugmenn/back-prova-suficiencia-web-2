using MeuBackEndApi.Src.Models;

namespace MeuBackEndApi.Src.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();
        Usuario BuscarPorId(int id);
        void Cadastrar(Usuario usuario);
    }
}
