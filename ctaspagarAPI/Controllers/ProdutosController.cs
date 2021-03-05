using CtasPagarAPI.Models;
using CtasPagarAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CtasPagarAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : Controller
    {

        private readonly IContaRepository repository;
        public ProdutosController(IContaRepository _context)
        {
            repository = _context;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Serviço ContaController, " + DateTime.Now.ToLongDateString();
        }

        [HttpGet("todos")]
        public async Task<ActionResult<IEnumerable<Conta>>> GetContas()
        {
            var contas = await repository.GetAll();

            if (contas == null)
            {
                return BadRequest("O estado da conta está null! - [GetContas]");
            }

            return Ok(contas.ToList());
        }

        // GET: api/Contas/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Conta>> GetConta(int id)
        {
            var conta = await repository.GetById(id);

            if (conta == null)
            {
                return NotFound("Id da conta não encontrado! - [GET api/Contas]");
            }

            return Ok(conta);
        }

        // POST api/<controller>  
        [HttpPost]
        public async Task<IActionResult> PostConta([FromBody]Conta conta)
        {
            if (conta == null)
            {
                return BadRequest("Estado da conta está null! - [PostConta]");
            }
            
            await repository.Insert(conta);

            return CreatedAtAction(nameof(GetConta), new { Id = conta.Id }, conta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConta(int id, Conta conta)
        {
            if (id != conta.Id)
            {
                return BadRequest($"O código da conta{id} não confere");
            }

            try
            {
                await repository.Update(id, conta);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok("Conta atualizada com sucesso! - [PutConta]");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Conta>> DeleteConta(int id)
        {
            var conta = await repository.GetById(id);
            if (conta == null)
            {
                return NotFound($"Conta de Id {id} não encontrada!");
            }

            await repository.Delete(id);

            return Ok(conta);
        }
    }
}
