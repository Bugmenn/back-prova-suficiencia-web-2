using AutoMapper;
using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Models;
using MeuBackEndApi.Src.Views;

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
            var listaUsuarios = await _repository.Listar();
            return _mapper.Map<List<UsuarioView>>(listaUsuarios);
        }

        public async Task<UsuarioView> BuscarPorId(int id)
        {
            var usuario = await _repository.BuscarPorId(id);

            if (usuario == null)
                throw new KeyNotFoundException("Usuário não encontrado");

            return _mapper.Map<UsuarioView>(usuario);
        }

        public void Cadastrar(UsuarioView view)
        {
            var novoUsuario = _mapper.Map<Usuario>(view);

            _repository.Cadastrar(novoUsuario);
        }
    }
}