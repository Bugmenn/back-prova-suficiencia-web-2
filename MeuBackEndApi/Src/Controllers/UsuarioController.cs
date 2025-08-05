using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<List<UsuarioView>> Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<UsuarioView> BuscarPorId(int id)
        {
            var usuario = _service.BuscarPorId(id);
            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Cadastrar([FromBody] UsuarioView view)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _service.Cadastrar(view);
            return Created("", view);
        }
    }
}
