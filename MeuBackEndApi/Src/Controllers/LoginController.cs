using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Services;
using MeuBackEndApi.Src.Views;
using Microsoft.AspNetCore.Mvc;

namespace MeuBackEndApi.Src.Controllers
{
    [ApiController]
    [Route("RestAPIFurb/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginAppService _loginAppService;

        public LoginController(ILoginAppService loginAppService)
        {
            _loginAppService = loginAppService;
        }

        [HttpPost]
        public IActionResult Login([FromBody] LoginView login)
        {
            var resultado = _loginAppService.RealizarLogin(login);

            if (!resultado.Sucesso)
                return Unauthorized(new { message = resultado.Mensagem });

            return Ok(new { token = resultado.Token });
        }
    }
}
