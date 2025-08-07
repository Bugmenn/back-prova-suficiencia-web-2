using MeuBackEndApi.Src.GenericModels;
using MeuBackEndApi.Src.Utils;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeuBackEndApi.Src.Models
{
    [Table("Usuarios")]
    public class Usuario : IEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Login do usuário
        /// </summary>
        [Required]
        public string UsuarioLogin { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Phone]
        public string Telefone { get; set; }

        /// <summary>
        /// Necessário para o Entity Framework do banco de dados
        /// </summary>
        public Usuario() { }

        public Usuario(int? id, string login, string nome, string email, string senha, string telefone)
        {
            Id = id ?? 0;
            UsuarioLogin = login;
            Nome = nome;
            Email = email;
            Senha = SenhaConverter.HashPassword(senha);
            Telefone = telefone;
        }
    }
}
