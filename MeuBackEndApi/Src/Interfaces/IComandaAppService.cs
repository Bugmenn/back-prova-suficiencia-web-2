using MeuBackEndApi.Src.Models;
using MeuBackEndApi.Src.Views.comanda;

namespace MeuBackEndApi.Src.Interfaces
{
    public interface IComandaAppService
    {
        Task<List<ComandaUsuarioView>> ListarUsuariosDasComandas();
        Task<ComandaCompletaView> BuscarComandaCompleta(int id);
        Task<ComandaCriadaView> CriarComanda(ComandaCompletaView novaComanda);
        Task AtualizarComanda(int id, ComandaUpdateView view);
        Task RemoverComanda(int id);
    }
}
