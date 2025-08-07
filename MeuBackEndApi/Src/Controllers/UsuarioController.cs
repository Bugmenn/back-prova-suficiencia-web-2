using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MeuBackEndApi.Src.Controllers
{
    [ApiController]
    [Route("RestAPIFurb/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _service;

        public UsuarioController(IUsuarioAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        [EndpointSummary("Lista de usuários")]
        public async Task<ActionResult<List<UsuarioView>>> Listar()
        {
            return Ok(await _service.Listar());
        }

        [HttpGet("{id}")]
        [Authorize]
        [EndpointSummary("Pega o usuário pelo id")]
        public async Task<ActionResult<UsuarioView>> BuscarPorId(int id)
        {
            var usuario = await _service.BuscarPorId(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        [AllowAnonymous]
        [EndpointSummary("Cadastro de usuário para fazer login")]
        public IActionResult Cadastrar([FromBody] UsuarioView view)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.Cadastrar(view);
            return Created("", view);
        }
    }
}
