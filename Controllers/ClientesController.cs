using fundamentosApi.Context;
using fundamentosApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fundamentosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly AgendaContext _context;

        public ClientesController(AgendaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult SelecionarTodos()
        {
            var clientes = _context.Clientes
                .Include(c => c.Contatos)
                .ToList();

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult SelecionarCliente(int id)
        {
            var cliente = _context.Clientes
                .Include(c => c.Contatos)
                .FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente);
        }

        [HttpGet("SelecionarPorNome/{nome}")]
        public IActionResult SelecionarPorNome(string nome)
        {
            var clientes = _context.Clientes
                .Where(c => c.Nome.Contains(nome))
                .ToList();

            if (!clientes.Any())
                return NotFound();

            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult CriarCliente(Clientes cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();

            return CreatedAtAction(nameof(SelecionarCliente), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarCliente(int id, Clientes cliente)
        {
            var clienteBanco = _context.Clientes.Find(id);

            if (clienteBanco == null)
                return NotFound();

            clienteBanco.Nome = cliente.Nome;
            clienteBanco.Email = cliente.Email;
            clienteBanco.AceitaComunicado = cliente.AceitaComunicado;
            clienteBanco.DataCadastro = cliente.DataCadastro;

            _context.SaveChanges();

            return Ok(clienteBanco);
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizarClienteParcial(int id, Clientes cliente)
        {
            var clienteBanco = _context.Clientes.Find(id);

            if (clienteBanco == null)
                return NotFound();

            foreach (var prop in typeof(Clientes).GetProperties())
            {
                if (prop.Name == "Id")
                    continue;

                if (!prop.PropertyType.IsValueType && prop.PropertyType != typeof(string))
                    continue;

                var valor = prop.GetValue(cliente);

                if (valor != null)
                {
                    prop.SetValue(clienteBanco, valor);
                }
            }

            _context.SaveChanges();

            return Ok(clienteBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
                return NotFound();

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return Ok("removido com sucesso");
        }
    }
}