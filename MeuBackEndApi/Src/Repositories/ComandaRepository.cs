using MeuBackEndApi.Src.Data;
using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Models;
using MeuBackEndApi.Src.Views.comanda;
using Microsoft.EntityFrameworkCore;

namespace MeuBackEndApi.Src.Repositories
{
    public class ComandaRepository : GenericRepository<Comanda>, IComandaRepository
    {
        public ComandaRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Comanda?> GetByIdWithProdutosAsync(int id)
        {
            return await _context.Comandas
                .Include(c => c.Produtos)
                .FirstOrDefaultAsync(c => c.Id == id);
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

        public async Task<Comanda> CriarComanda(ComandaCompletaView novaComanda)
        {
            // IDs recebidos
            var idsRecebidos = novaComanda.Produtos.Select(p => p.Id).ToList();

            // Buscar os produtos já existentes no banco
            var produtosExistentes = await GetProdutosByIdsAsync(idsRecebidos);

            // Identificar os produtos que ainda não existem
            var idsExistentes = produtosExistentes.Select(p => p.Id).ToHashSet();

            var novosProdutos = novaComanda.Produtos
                .Where(p => !idsExistentes.Contains(p.Id))
                .Select(p => new Produto
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco
                })
                .ToList();

            // Adicionar novos produtos ao banco
            if (novosProdutos.Any())
            {
                _context.Produtos.AddRange(novosProdutos);
                await _context.SaveChangesAsync(); // salvar antes de associar à comanda
            }

            // Unir todos os produtos (novos + existentes)
            var todosProdutos = produtosExistentes.Concat(novosProdutos).ToList();

            var nova = new Comanda
            {
                IdUsuario = novaComanda.IdUsuario,
                NomeUsuario = novaComanda.NomeUsuario,
                TelefoneUsuario = novaComanda.TelefoneUsuario,
                Produtos = todosProdutos
            };

            await _context.Comandas.AddAsync(nova);
            await _context.SaveChangesAsync();

            return nova;
        }
    }
}