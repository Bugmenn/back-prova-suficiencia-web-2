using MeuBackEndApi.Src.Views;

namespace MeuBackEndApi.Src.Interfaces
{
    public interface IUsuarioAppService
    {
        List<UsuarioView> Listar();
        UsuarioView BuscarPorId(int id);
        void Cadastrar(UsuarioView view);
    }
}