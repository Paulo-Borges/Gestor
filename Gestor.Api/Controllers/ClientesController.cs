using Gestor.Api.Data;
using Gestor.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly AplicationDbContext _context;

        public ClientesController(AplicationDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCliente([FromBody] Cliente cliente)
        {
            if (cliente == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetClienteById), new { id = cliente.Id }, cliente);
        }   
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClienteById(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }
    }
}
