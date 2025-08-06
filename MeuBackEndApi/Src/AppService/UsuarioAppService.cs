using AutoMapper;
using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Models;
using MeuBackEndApi.Src.Views;
using System.Threading.Tasks;

namespace MeuBackEndApi.Src.AppService
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioAppService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UsuarioView>> Listar()
        {
            return (await _repository.Listar()).Select(usuario => new UsuarioView
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Telefone = usuario.Telefone
            }).ToList();
        }

        public async Task<UsuarioView> BuscarPorId(int id)
        {
            var usuario = await _repository.BuscarPorId(id);
            if (usuario == null) return null;

            return new UsuarioView
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Telefone = usuario.Telefone
            };
        }

        public void Cadastrar(UsuarioView view)
        {
            var novoUsuario = _mapper.Map<Usuario>(view);

            _repository.Cadastrar(novoUsuario);
        }
    }
}