using System.ComponentModel.DataAnnotations;

namespace MeuBackEndApi.Src.Models
{
    public class Comanda
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [Required, StringLength(100)]
        public string NomeUsuario { get; set; } = null!;

        [Required, Phone]
        public string TelefoneUsuario { get; set; } = null!;

        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
