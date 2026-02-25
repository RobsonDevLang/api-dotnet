
using fundamentosApi.Context;
using fundamentosApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace fundamentosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatosController : ControllerBase
    {
        private readonly AgendaContext _contex;

        public ContatosController(AgendaContext context)
        {
            _contex = context;
        }

        [HttpGet]
        public IActionResult SelecionarTodos()
        {
            var contatos = _contex.Contatos.ToList();
            return Ok(contatos);
        }

        [HttpPost]
        public IActionResult CriarContato(Contatos contato)
        {
            _contex.Add(contato);
            _contex.SaveChanges();
            return CreatedAtAction(nameof(SelecionarContato), new {id = contato.Id}, contato);
        }

        [HttpGet("{id}")]
        public IActionResult SelecionarContato(int id)
        {
            var contato = _contex.Contatos.Find(id);
            if (contato == null) { return NotFound(); }

            return Ok(contato);
        }

        [HttpGet("SelecionarPorNomeContato/{nome}")]
        public IActionResult SelecionarPorNomeContato(string nome)
        {
            var contato = _contex.Contatos.Where(x => x.Nome.Contains(nome));
            if (contato == null) { return NotFound(); }
            return Ok(contato);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarContato(int id, Contatos contato)
        {
            var contatoBanco = _contex.Contatos.Find(id);
            if (contatoBanco == null)
            {
                return NotFound();
            }
            else
            {
                contatoBanco.Nome = contato.Nome;
                contatoBanco.Telefone = contato.Telefone;
                contatoBanco.Ativo = contato.Ativo;
                contatoBanco.ClienteId = contato.ClienteId;

                _contex.SaveChanges();

                return Ok(contatoBanco);
            }

        }


        [HttpPatch("{id}")]
        public IActionResult AtualizarContatoParcial(int id, Contatos contato)
        {
            var contatoBanco = _contex.Contatos.Find(id);

            if (contatoBanco == null)
                return NotFound();

            foreach (var prop in typeof(Contatos).GetProperties())
            {
                if (prop.Name == "Id")
                    continue;
                if (prop.Name == "ClienteId" && (int)prop.GetValue(contato)! == 0)
                    continue;
                if (!prop.PropertyType.IsValueType && prop.PropertyType != typeof(string))
                    continue;

                var valor = prop.GetValue(contato);

                if (valor != null)
                {
                    prop.SetValue(contatoBanco, valor);
                }
            }

            _contex.SaveChanges();

            return Ok(contatoBanco);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarContato(int id)
        {
            var contato = _contex.Contatos.Find(id);
            if (contato == null) { return NotFound(); }

            _contex.Contatos.Remove(contato);
            _contex.SaveChanges();
            return Ok("removido com sucesso");
        }

    }
}