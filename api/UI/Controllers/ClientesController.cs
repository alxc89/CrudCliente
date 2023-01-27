using AutoMapper;
using CrudCliente.api.Application.Implementation.Interface;
using CrudCliente.api.Application.Implementation.Mappings;
using CrudCliente.api.Domain.Entities;
using CrudCliente.api.UI.DTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudCliente.api.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteServices _clienteServices;
        private readonly IMapper _mapper;

        public ClientesController(IClienteServices clienteServices, IMapper mapper)
        {
            _clienteServices = clienteServices;
            _mapper = mapper;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _clienteServices.GetAsync());
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _clienteServices.GetByIdAsync(id));
        }

        // POST api/<ClientesController>
        [HttpPost]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] NovoClienteDTO novoClienteDTO)
        {
            var novoCliente = _mapper.Map<Cliente>(novoClienteDTO);
            await _clienteServices.InsertAsync(novoCliente);
            return CreatedAtAction(nameof(Get), new { novoCliente.Id }, novoCliente);
        }

        // PUT api/<ClientesController>/5
        [HttpPut]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put([FromBody] AlteraClienteDTO alteraClienteDTO)
        {
            var clienteAtualizado = _mapper.Map<Cliente>(alteraClienteDTO);
            await _clienteServices.UpdateAsync(clienteAtualizado);
            if (clienteAtualizado == null)
            {
                return NotFound();
            }

            return Ok(clienteAtualizado);
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteServices.DeleteAsync(id);
            return NoContent();
        }
    }
}
