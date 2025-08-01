using MeuBackEndApi.Src.Objects;

namespace MeuBackEndApi.Src.Interfaces
{
    public interface IMensagemAppService
    {
        string GetMensagem(string nome);
        Pessoa GetObjeto(string nome);
    }
}
