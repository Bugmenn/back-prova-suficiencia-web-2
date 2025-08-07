using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Services;
using MeuBackEndApi.Src.Utils;
using MeuBackEndApi.Src.Views;

namespace MeuBackEndApi.Src.AppService
{
    public class LoginAppService : ILoginAppService
    {
        private readonly ILoginRepository _repository;
        private readonly TokenService _tokenService;

        public LoginAppService(ILoginRepository repository, TokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }

        public ResultadoLoginView RealizarLogin(LoginView login)
        {
            var usuario = _repository.BuscarPorUsuario(login.Usuario);

            if (usuario == null)
                return new ResultadoLoginView { Sucesso = false, Mensagem = "Usuário não encontrado" };

            bool senhaValida = SenhaConverter.VerifyPassword(login.Senha, usuario.Senha);

            if (!senhaValida)
                return new ResultadoLoginView { Sucesso = false, Mensagem = "Senha inválida" };

            var token = _tokenService.GerarToken(usuario.UsuarioLogin);

            return new ResultadoLoginView { Sucesso = true, Token = token };
        }
    }
}
