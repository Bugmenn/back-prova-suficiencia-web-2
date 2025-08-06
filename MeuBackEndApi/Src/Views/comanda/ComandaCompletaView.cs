namespace MeuBackEndApi.Src.Views.comanda
{
    public class ComandaCompletaView
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string TelefoneUsuario { get; set; }
        public List<ProdutoView> Produtos { get; set; } = new();
    }
}
