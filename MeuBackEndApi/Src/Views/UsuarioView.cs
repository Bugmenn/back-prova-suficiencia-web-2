using System.ComponentModel.DataAnnotations;

namespace MeuBackEndApi.Src.Views
{
    public class UsuarioView
    {
        public int Id { get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required, Phone]
        public string Telefone { get; set; }

        public UsuarioView() { }

        public UsuarioView(int id, string usuario, string nome, string email, string senha, string telefone)
        {
            Id = id;
            Usuario = usuario;
            Nome = nome;
            Email = email;
            Senha = senha;
            Telefone = telefone;
        }
    }
}
