using MeuBackEndApi.Src.GenericModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuBackEndApi.Src.Models
{
    [Table("Produtos")]
    public class Produto : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(150)]
        public string Nome { get; set; } = null!;

        [Required]
        public decimal Preco { get; set; }

        /// <summary>
        /// Necessário para o Entity Framework do banco de dados
        /// </summary>
        public Produto() { }

        public Produto(int? id, string nome, decimal preco)
        {
            Id = id ?? 0;
            Nome = nome;
            Preco = preco;
        }
    }
}
