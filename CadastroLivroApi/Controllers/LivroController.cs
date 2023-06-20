using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroLivroApi.Models;
using CadastroLivroApi.DAOs;
using CadastroLivroApi.Controllers.Extensoes;
using CadastroLivroDll.DOs;

namespace CadastroLivroApi.Controllers
{
        [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        // GET: api/Livro
        [HttpGet]
        public async Task<ActionResult<IList<LivroDO>>> Get()
        {
            return Ok((await dao.RetornarTodosAsync()).ToDO());
        }

        // GET: api/Livro/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LivroDO>> GetPorId(string id)
        {
            var objeto = await dao.RetornarPorIdAsync(id);

            if (objeto == null)
                return NotFound();
            
            return Ok(objeto.ToDO());
        }

        // POST: api/Livro
        [HttpPost]
        public async Task<ActionResult<LivroDO>> Post(LivroDO objDO)
        {
            if (objDO == null)
                return Problem("O Livro que você está tentando inserir está nulo.");

            var objeto = await objDO.ToModel();

            await dao.InserirAsync(objeto);

            objDO = objeto.ToDO();

            return CreatedAtAction(nameof(GetPorId), new { id = objDO.Id }, objDO);
        }

        // PUT: api/Livro/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, LivroDO novoLivroDO)
        {
            if (id != novoLivroDO.Id)
                return Problem("Como você pode me enviar um id na rota diferente do id do objeto?");
                //return BadRequest();
            
            try
            {
                await dao.AlterarAsync(await novoLivroDO.ToModel());
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Livro/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await dao.ExcluirAsync(id);
            
            return NoContent();
        }

        private LivroDAO dao = new LivroDAO();
    }
}