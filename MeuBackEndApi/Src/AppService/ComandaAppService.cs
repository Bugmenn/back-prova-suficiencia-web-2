using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Models;
using MeuBackEndApi.Src.Views;

namespace MeuBackEndApi.Src.AppService
{
    public class ComandaAppService : IComandaAppService
    {
        private readonly IComandaRepository _repository;

        public ComandaAppService(IComandaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ComandaView>> GetAllAsync()
        {
            var comandas = await _repository.GetAllAsync();
            return comandas.Select(c => new ComandaView
            {
                IdUsuario = c.IdUsuario,
                NomeUsuario = c.NomeUsuario,
                TelefoneUsuario = c.TelefoneUsuario
            }).ToList();
        }

        public async Task<ComandaView?> GetByIdAsync(int id)
        {
            var comanda = await _repository.GetByIdWithProdutosAsync(id);
            if (comanda == null) return null;

            return new ComandaView
            {
                Id = comanda.Id,
                IdUsuario = comanda.IdUsuario,
                NomeUsuario = comanda.NomeUsuario,
                TelefoneUsuario = comanda.TelefoneUsuario,
                Produtos = comanda.Produtos.Select(p => new ProdutoView
                {
                    Id = p.Id,
                    Nome = p.Nome,
                    Preco = p.Preco
                }).ToList()
            };
        }

        public async Task AddAsync(ComandaView view)
        {
            var comanda = new Comanda
            {
                IdUsuario = view.IdUsuario,
                NomeUsuario = view.NomeUsuario,
                TelefoneUsuario = view.TelefoneUsuario
            };

            // Busca os produtos existentes no banco (evita duplicar)
            if (view.Produtos != null && view.Produtos.Any())
            {
                var produtosIds = view.Produtos.Select(p => p.Id).ToList();
                var produtosExistentes = await _repository.GetProdutosByIdsAsync(produtosIds);
                comanda.Produtos = produtosExistentes;
            }

            await _repository.AddAsync(comanda);
        }

        public async Task UpdatePartialAsync(int id, ComandaView view)
        {
            var comanda = await _repository.GetByIdWithProdutosAsync(id);
            if (comanda == null)
                throw new KeyNotFoundException("Comanda não encontrada");

            // Atualiza campos se foram enviados (não nulos ou default)
            if (view.IdUsuario != 0)
                comanda.IdUsuario = view.IdUsuario;

            if (!string.IsNullOrEmpty(view.NomeUsuario))
                comanda.NomeUsuario = view.NomeUsuario;

            if (!string.IsNullOrEmpty(view.TelefoneUsuario))
                comanda.TelefoneUsuario = view.TelefoneUsuario;

            if (view.Produtos != null && view.Produtos.Any())
            {
                var produtosIds = view.Produtos.Select(p => p.Id).ToList();
                var produtosExistentes = await _repository.GetProdutosByIdsAsync(produtosIds);
                comanda.Produtos = produtosExistentes;
            }

            await _repository.UpdateAsync(comanda);
        }

        public async Task UpdateAsync(int id, ComandaView view)
        {
            var comanda = await _repository.GetByIdAsync(id);
            if (comanda == null)
                throw new KeyNotFoundException("Comanda não encontrada");

            comanda.IdUsuario = view.IdUsuario;
            comanda.NomeUsuario = view.NomeUsuario;
            comanda.TelefoneUsuario = view.TelefoneUsuario;

            await _repository.UpdateAsync(comanda);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
