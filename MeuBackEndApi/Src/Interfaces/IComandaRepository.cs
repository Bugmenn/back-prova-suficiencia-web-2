using MeuBackEndApi.Src.Models;
using MeuBackEndApi.Src.Views.comanda;

namespace MeuBackEndApi.Src.Interfaces
{
    public interface IComandaRepository
    {
        Task<List<Comanda>> GetAllAsync();
        Task<Comanda?> GetByIdAsync(int id);
        Task<Comanda?> GetByIdWithProdutosAsync(int id);
        Task AddAsync(Comanda comanda);
        Task UpdateAsync(Comanda comanda);
        Task DeleteAsync(int id);
        Task<List<Produto>> GetProdutosByIdsAsync(List<int> ids);
        Task<Comanda> CriarComanda(ComandaCompletaView novaComanda);
    }
}