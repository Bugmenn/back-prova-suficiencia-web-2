using MeuBackEndApi.Src.Data;
using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Models;

namespace MeuBackEndApi.Src.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AppDbContext _context;

        public LoginRepository(AppDbContext context)
        {
            _context = context;
        }

        public Usuario BuscarPorUsuario(string usuarioLogin)
        {
            return _context.Set<Usuario>().FirstOrDefault(u => u.UsuarioLogin == usuarioLogin);
        }
    }
}
