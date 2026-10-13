using Gestor.Api.Data;
using Gestor.Api.DTOs;
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
        public async Task<ActionResult<ClienteResponseDto>> CreateCliente([FromBody] ClienteCreateDto clienteDto)
        {
            if (clienteDto == null || !ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cliente = new Cliente
            {
                Nome = clienteDto.Nome,
                Email = clienteDto.Email,
                Telefone = clienteDto.Telefone,
                DataCadastro = DateTime.UtcNow
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            var ResponseDto = new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                DataCadastro = cliente.DataCadastro
            };
            return CreatedAtAction(nameof(GetClienteById), new { id = ResponseDto.Id }, ResponseDto);
        }   
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteResponseDto>> GetClienteById(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            var clienteResponseDto = new ClienteResponseDto
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                DataCadastro = cliente.DataCadastro
            };
            return Ok(clienteResponseDto);
        }
    }
}
