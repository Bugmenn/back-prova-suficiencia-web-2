using System.ComponentModel.DataAnnotations;

namespace MeuBackEndApi.Src.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Nome { get; set; } = null!;

        [Required]
        public decimal Preco { get; set; }
    }
}
