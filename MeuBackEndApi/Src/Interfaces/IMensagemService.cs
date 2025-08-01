using MeuBackEndApi.Src.Objects;

namespace MeuBackEndApi.Src.Interfaces
{
    public interface IMensagemService
    {
        string GetMensagem(string nome);
        Pessoa GetObjeto(string nome);
    }
}
