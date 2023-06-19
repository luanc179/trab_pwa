using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CadastroAtletaApi.Models;
using CadastroAtletaApi.DAOs;
using CadastroAtletaApi.Controllers.Extensoes;
using CadastroAtletaDll.DOs;

namespace CadastroAtletaRecordApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AtletaRecordController : ControllerBase
    {
        // GET: api/AtletaRecord
        [HttpGet]
        public async Task<ActionResult<IList<AtletaRecordDO>>> Get()
        {
            return Ok((await dao.RetornarTodosAsync()).ToDO());
        }

        // GET: api/AtletaRecord
        [HttpGet("mestre/{idMestre}")]
        public async Task<ActionResult<IList<AtletaRecordDO>>> GetPorIdMestre(string idMestre)
        {
            return Ok((await dao.RetornarPorIdMestreAsync(idMestre)).ToDO());
        }

        // GET: api/AtletaRecord/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AtletaRecordDO>> GetPorId(string id)
        {
            var objeto = await dao.RetornarPorIdAsync(id);

            if (objeto == null)
                return NotFound();
            
            return Ok(objeto.ToDO());
        }

        // POST: api/AtletaRecord
        [HttpPost]
        public async Task<ActionResult<AtletaRecordDO>> Post(AtletaRecordDO objDO)
        {
            if (objDO == null)
                return Problem("O record que você está tentando inserir está nulo.");

            var objeto = await objDO.ToModel();

            await dao.InserirAsync(objeto);

            objDO = objeto.ToDO();

            return CreatedAtAction(nameof(GetPorId), new { id = objDO.Id }, objDO);
        }

        // PUT: api/AtletaRecord/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, AtletaRecordDO novoAtletaRecordDO)
        {
            if (id != novoAtletaRecordDO.Id)
                return Problem("Como você pode me enviar um id na rota diferente do id do objeto?");
                //return BadRequest();
            
            try
            {
                await dao.AlterarAsync(await novoAtletaRecordDO.ToModel());
            }
            catch (Exception)
            {
                throw;
            }

            return NoContent();
        }

        // DELETE: api/AtletaRecord/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await dao.ExcluirAsync(id);
            
            return NoContent();
        }

        private AtletaRecordDAO dao = new AtletaRecordDAO();
    }
}