using MeuBackEndApi.Src.Views;

namespace MeuBackEndApi.Src.Interfaces
{
    public interface IComandaAppService
    {
        Task<List<ComandaView>> GetAllAsync();
        Task<ComandaView?> GetByIdAsync(int id);
        Task AddAsync(ComandaView view);
        Task UpdateAsync(int id, ComandaView view);
        Task DeleteAsync(int id);
    }
}
