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

        public async Task<Comanda?> GetByIdAsync(int id)
        {
            return await GetByIdAsync(id, include => include.Produtos);
        }

        public async Task UpdateAsync(Comanda comanda)
        {
            base.Update(comanda);
            await SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var comanda = await GetByIdAsync(id);

            if (comanda != null)
            {
                Delete(comanda);
                await SaveAsync();
            }
        }

        public async Task<List<Produto>> GetProdutosByIdsAsync(List<int> ids)
        {
            return await _context.Set<Produto>()
                .Where(p => ids.Contains(p.Id))
                .ToListAsync();
        }

        public async Task<Comanda> CriarComanda(ComandaCompletaView novaComanda)
        {
            var existeUsuario = await _context.Set<Usuario>().AnyAsync(a => a.Id == novaComanda.IdUsuario);

            if (!existeUsuario)
                throw new KeyNotFoundException("Usuário não encontrado");

            var idsRecebidos = novaComanda.Produtos.Select(p => p.Id).ToList();

            var produtosExistentes = await GetProdutosByIdsAsync(idsRecebidos);

            var idsExistentes = produtosExistentes.Select(p => p.Id).ToHashSet();

            var novosProdutos = novaComanda.Produtos
                .Where(p => !idsExistentes.Contains(p.Id))
                .Select(p => new Produto(p.Id, p.Nome, p.Preco))
                .ToList();

            if (novosProdutos.Any())
            {
                _context.Set<Produto>().AddRange(novosProdutos);
                await _context.SaveChangesAsync();
            }

            var todosProdutos = produtosExistentes.Concat(novosProdutos).ToList();

            var nova = new Comanda(0,novaComanda.IdUsuario, novaComanda.NomeUsuario, novaComanda.TelefoneUsuario, todosProdutos);

            await _context.Set<Comanda>().AddAsync(nova);
            await _context.SaveChangesAsync();

            return nova;
        }
    }
}