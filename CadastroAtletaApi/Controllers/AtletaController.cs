using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroAtletaApi.Models;
using CadastroAtletaApi.DAOs;
using CadastroAtletaApi.Controllers.Extensoes;
using CadastroAtletaDll.DOs;

namespace CadastroAtletaApi.Controllers
{
        [ApiController]
    [Route("api/[controller]")]
    public class AtletaController : ControllerBase
    {
        // GET: api/Atleta
        [HttpGet]
        public async Task<ActionResult<IList<AtletaDO>>> Get()
        {
            return Ok((await dao.RetornarTodosAsync()).ToDO());
        }

        // GET: api/Atleta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AtletaDO>> GetPorId(string id)
        {
            var objeto = await dao.RetornarPorIdAsync(id);

            if (objeto == null)
                return NotFound();
            
            return Ok(objeto.ToDO());
        }

        // POST: api/Atleta
        [HttpPost]
        public async Task<ActionResult<AtletaDO>> Post(AtletaDO objDO)
        {
            if (objDO == null)
                return Problem("O Atleta que você está tentando inserir está nulo.");

            var objeto = await objDO.ToModel();

            await dao.InserirAsync(objeto);

            objDO = objeto.ToDO();

            return CreatedAtAction(nameof(GetPorId), new { id = objDO.Id }, objDO);
        }

        // PUT: api/Atleta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, AtletaDO novoAtletaDO)
        {
            if (id != novoAtletaDO.Id)
                return Problem("Como você pode me enviar um id na rota diferente do id do objeto?");
                //return BadRequest();
            
            try
            {
                await dao.AlterarAsync(await novoAtletaDO.ToModel());
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Atleta/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await dao.ExcluirAsync(id);
            
            return NoContent();
        }

        private AtletaDAO dao = new AtletaDAO();
    }
}