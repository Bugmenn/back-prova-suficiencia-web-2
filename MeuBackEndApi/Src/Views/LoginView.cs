using System.ComponentModel.DataAnnotations;

namespace MeuBackEndApi.Src.Views
{
    public class LoginView
    {
        [Required]
        public string Usuario { get; set; }
        [Required]
        public string Senha { get; set; }
    }
}
