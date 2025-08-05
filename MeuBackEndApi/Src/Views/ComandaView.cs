namespace MeuBackEndApi.Src.Views
{
    public class ComandaView
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; } = null!;
        public string TelefoneUsuario { get; set; } = null!;
        public List<ProdutoView> Produtos { get; set; } = new List<ProdutoView>();
    }
}
