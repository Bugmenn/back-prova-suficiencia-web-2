using MeuBackEndApi.Src.Data;
using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace MeuBackEndApi.Src.Repositories
{
    public class ComandaRepository : IComandaRepository
    {
        private readonly AppDbContext _context;

        public ComandaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Comanda>> GetAllAsync()
        {
            return await _context.Comandas.ToListAsync();
        }

        public async Task<Comanda?> GetByIdAsync(int id)
        {
            return await _context.Comandas.FindAsync(id);
        }

        public async Task<Comanda?> GetByIdWithProdutosAsync(int id)
        {
            return await _context.Comandas
                .Include(c => c.Produtos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Comanda comanda)
        {
            _context.Comandas.Add(comanda);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comanda comanda)
        {
            _context.Comandas.Update(comanda);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var comanda = await _context.Comandas.FindAsync(id);
            if (comanda != null)
            {
                _context.Comandas.Remove(comanda);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Produto>> GetProdutosByIdsAsync(List<int> ids)
        {
            return await _context.Produtos
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();
        }
    }
}