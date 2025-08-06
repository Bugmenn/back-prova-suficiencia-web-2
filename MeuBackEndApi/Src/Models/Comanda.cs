using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuBackEndApi.Src.Models
{
    public class Comanda
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; } = null!;

        [Required, StringLength(100)]
        public string NomeUsuario { get; set; } = null!;

        [Required, Phone]
        public string TelefoneUsuario { get; set; } = null!;

        public List<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
