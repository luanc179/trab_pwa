using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroLivroApi.Models;
using CadastroLivroApi.DAOs;
using CadastroLivroApi.Controllers.Extensoes;
using CadastroLivroDll.DOs;

namespace CadastroLivroAutoresApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroAutoresController : ControllerBase
    {
        // GET: api/LivroAutores
        [HttpGet]
        public async Task<ActionResult<IList<LivroAutoresDO>>> Get()
        {
            return Ok((await dao.RetornarTodosAsync()).ToDO());
        }

        // GET: api/LivroAutores
        [HttpGet("mestre/{idMestre}")]
        public async Task<ActionResult<IList<LivroAutoresDO>>> GetPorIdMestre(string idMestre)
        {
            return Ok((await dao.RetornarPorIdMestreAsync(idMestre)).ToDO());
        }

        // GET: api/LivroAutores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LivroAutoresDO>> GetPorId(string id)
        {
            var objeto = await dao.RetornarPorIdAsync(id);

            if (objeto == null)
                return NotFound();
            
            return Ok(objeto.ToDO());
        }

        // POST: api/LivroAutores
        [HttpPost]
        public async Task<ActionResult<LivroAutoresDO>> Post(LivroAutoresDO objDO)
        {
            if (objDO == null)
                return Problem("O autores que você está tentando inserir está nulo.");

            var objeto = await objDO.ToModel();

            await dao.InserirAsync(objeto);

            objDO = objeto.ToDO();

            return CreatedAtAction(nameof(GetPorId), new { id = objDO.Id }, objDO);
        }

        // PUT: api/LivroAutores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, LivroAutoresDO novoLivroAutoresDO)
        {
            if (id != novoLivroAutoresDO.Id)
                return Problem("Como você pode me enviar um id na rota diferente do id do objeto?");
                //return BadRequest();
            
            try
            {
                await dao.AlterarAsync(await novoLivroAutoresDO.ToModel());
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/LivroAutores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await dao.ExcluirAsync(id);
            
            return NoContent();
        }

        private LivroAutoresDAO dao = new LivroAutoresDAO();
    }
}