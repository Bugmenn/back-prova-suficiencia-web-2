using MeuBackEndApi.Src.Data;
using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Models;
using Microsoft.EntityFrameworkCore;

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
            return _context.Usuarios.FirstOrDefault(u => u.UsuarioLogin == usuarioLogin);
        }
    }
}
