using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Views.comanda;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MeuBackEndApi.Src.Controllers
{
    [ApiController]
    [Route("RestAPIFurb/comandas")]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaAppService _comandaAppService;

        public ComandaController(IComandaAppService comandaAppService)
        {
            _comandaAppService = comandaAppService;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<ComandaUsuarioView>>> ListarUsuarios()
        {
            var usuarios = await _comandaAppService.ListarUsuariosDasComandas();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ComandaCompletaView>> BuscarPorId(int id)
        {
            var comanda = await _comandaAppService.BuscarComandaCompleta(id);

            if (comanda == null)
                return NotFound();

            return Ok(comanda);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ComandaCriadaView>> Criar([FromBody] ComandaCompletaView view)
        {
            var criada = await _comandaAppService.CriarComanda(view);
            return CreatedAtAction(nameof(BuscarPorId), new { id = criada.Id }, criada);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> AtualizarComanda(int id, [FromBody] ComandaUpdateView view)
        {
            await _comandaAppService.AtualizarComanda(id, view);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> RemoverComanda(int id)
        {
            await _comandaAppService.RemoverComanda(id);

            return Ok(new
            {
                success = new
                {
                    text = "comanda removida"
                }
            });
        }
    }
}
