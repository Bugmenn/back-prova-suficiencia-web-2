using MeuBackEndApi.Src.Views;

namespace MeuBackEndApi.Src.Interfaces
{
    public interface ILoginAppService
    {
        ResultadoLoginView RealizarLogin(LoginView login);
    }
}
