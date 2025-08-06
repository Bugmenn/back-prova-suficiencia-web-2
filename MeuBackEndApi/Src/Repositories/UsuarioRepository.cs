using MeuBackEndApi.Src.Data;
using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Models;
using System.Threading.Tasks;

namespace MeuBackEndApi.Src.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Usuario>> Listar() => await GetAllAsync();

        public async Task<Usuario> BuscarPorId(int id) => await GetByIdAsync(id);

        public async Task Cadastrar(Usuario usuario)
        {
            await AddAsync(usuario);
            await SaveAsync();
        }
    }
}
