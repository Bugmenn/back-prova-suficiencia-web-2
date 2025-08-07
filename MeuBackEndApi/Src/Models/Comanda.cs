using MeuBackEndApi.Src.GenericModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuBackEndApi.Src.Models
{
    [Table("Comandas")]
    public class Comanda : IEntity
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

        [Required]
        public List<Produto> Produtos { get; set; } = new List<Produto>();

        public Comanda() { }

        public Comanda(int? id, int idUsuario, string nomeUsuario, string telefoneUsuario, List<Produto> produtos)
        {
            Id = id ?? 0;
            IdUsuario = idUsuario;
            NomeUsuario = nomeUsuario;
            TelefoneUsuario = telefoneUsuario;
            Produtos = produtos;
        }
    }
}
