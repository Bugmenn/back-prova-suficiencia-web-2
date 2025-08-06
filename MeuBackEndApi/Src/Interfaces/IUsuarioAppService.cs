using MeuBackEndApi.Src.Views;

namespace MeuBackEndApi.Src.Interfaces
{
    public interface IUsuarioAppService
    {
        Task<List<UsuarioView>> Listar();
        Task<UsuarioView> BuscarPorId(int id);
        void Cadastrar(UsuarioView view);
    }
}