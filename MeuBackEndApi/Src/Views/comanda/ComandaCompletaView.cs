using System.ComponentModel.DataAnnotations;

namespace MeuBackEndApi.Src.Views.comanda
{
    public class ComandaCompletaView
    {
        [Required]
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        [Required, Phone]
        public string TelefoneUsuario { get; set; }
        [Required]
        public List<ProdutoView> Produtos { get; set; } = new();
    }
}
