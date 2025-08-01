using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Objects;

namespace MeuBackEndApi.Src.AppService
{
    public class MensagemAppService : IMensagemAppService
    {
        public string GetMensagem(string nome)
        {
            return $"Olá, {nome} do back-end em C#";
        }

        public Pessoa GetObjeto(string nome)
        {
            return new Pessoa
            {
                Nome = $"Olá {nome}",
                Data = DateTime.Now.ToString("dd/MM/yyyy")
            };
        }
    }
}
