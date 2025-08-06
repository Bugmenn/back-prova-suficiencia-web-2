using AutoMapper;
using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Models;
using MeuBackEndApi.Src.Views;
using MeuBackEndApi.Src.Views.comanda;

namespace MeuBackEndApi.Src.AppService
{
    public class ComandaAppService : IComandaAppService
    {
        private readonly IComandaRepository _repository;
        private readonly IMapper _mapper;

        public ComandaAppService(IComandaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ComandaUsuarioView>> ListarUsuariosDasComandas()
        {
            var comandas = await _repository.GetAllAsync();
            return _mapper.Map<List<ComandaUsuarioView>>(comandas);
        }

        public async Task<ComandaCompletaView> BuscarComandaCompleta(int id)
        {
            var comanda = await _repository.GetByIdWithProdutosAsync(id);

            if (comanda == null)
                throw new KeyNotFoundException("Comanda não encontrada");

            return _mapper.Map<ComandaCompletaView>(comanda);
        }

        public async Task<ComandaCriadaView> CriarComanda(ComandaCompletaView novaComanda)
        {
            var comandaCriada = await _repository.CriarComanda(novaComanda);

            return _mapper.Map<ComandaCriadaView>(comandaCriada);
        }

        public async Task AtualizarComanda(int id, ComandaUpdateView view)
        {
            var comanda = await _repository.GetByIdWithProdutosAsync(id);

            if (comanda == null)
                throw new KeyNotFoundException("Comanda não encontrada");

            // Atualizar apenas os campos enviados
            if (view.Produtos != null)
            {
                foreach (var produtoView in view.Produtos)
                {
                    var produtoExistente = comanda.Produtos.FirstOrDefault(p => p.Id == produtoView.Id);

                    if (produtoExistente != null)
                    {
                        produtoExistente.Nome = produtoView.Nome ?? produtoExistente.Nome;
                        produtoExistente.Preco = produtoView.Preco;
                    }
                    else
                    {
                        // Se produto não existir na comanda, adiciona
                        comanda.Produtos.Add(new Produto
                        {
                            Id = produtoView.Id,
                            Nome = produtoView.Nome,
                            Preco = produtoView.Preco
                        });
                    }
                }
            }

            await _repository.UpdateAsync(comanda);
        }

        public async Task RemoverComanda(int id)
        {
            var comanda = await _repository.GetByIdAsync(id);

            if (comanda == null)
                throw new KeyNotFoundException("Comanda não encontrada");

            await _repository.DeleteAsync(comanda.Id);
        }
    }
}
