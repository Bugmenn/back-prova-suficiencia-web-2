using MeuBackEndApi.Src.Interfaces;
using MeuBackEndApi.Src.Views;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuBackEndApi.Src.Controllers
{
    [ApiController]
    [Route("RestAPIFurb/[controller]")]
    public class ComandaController : ControllerBase
    {
        private readonly IComandaAppService _service;

        public ComandaController(IComandaAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var comandas = await _service.GetAllAsync();
            return Ok(comandas);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var comanda = await _service.GetByIdAsync(id);
            if (comanda == null)
                return NotFound(new { message = "Comanda não encontrada" });

            return Ok(comanda);
        }

        [HttpPost]
        [Authorize] // Protegendo o serviço, só usuário autenticado pode criar
        public async Task<IActionResult> Create([FromBody] ComandaView novaComanda)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.AddAsync(novaComanda);
                return CreatedAtAction(nameof(GetById), new { id = novaComanda.IdUsuario }, novaComanda);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] ComandaView view)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.UpdateAsync(id, view);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Comanda não encontrada" });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
