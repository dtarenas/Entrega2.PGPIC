using Entrega2.PGPIC.API.Data;
using Entrega2.PGPIC.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entrega2.PGPIC.API.Controllers
{
    [Route("api/researchers")]
    [ApiController]
    public class ResearcherController : ControllerBase
    {
        private readonly PGPICContext _context;

        public ResearcherController(PGPICContext context)
        {
            _context = context;
        }

        //Metodo Get por lista--- Select * From Researchers
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Researchers.ToListAsync());
        }

        //Metodo post' Guardar registros
        [HttpPost]
        public async Task<ActionResult> Post(Researcher researcher)
        {
            if (await _context.Researchers.AnyAsync(x => x.Name.ToUpper() == researcher.Name.ToUpper()))
            {
                return BadRequest($"Researcher with name: {researcher.Name} already exists");
            }

            _context.Researchers.Add(researcher);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Metodo Get por parametro' Select * From Researchers
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var Researcher = await _context.Researchers.FirstOrDefaultAsync(x => x.Id == id);
            if (Researcher == null)
            {
                return NotFound(Researcher); //404
            }

            return Ok(Researcher);
        }

        //Metodo Put - Actualizar registros

        [HttpPut]
        public async Task<ActionResult> Put(Researcher researcher)
        {
            if (!await _context.Researchers.AnyAsync(x => x.Id == researcher.Id))
            {
                return NotFound();
            }

            _context.Researchers.Update(researcher);
            await _context.SaveChangesAsync();
            return Ok(researcher);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.Researchers
                .Where(x => x.Id == id)
                .ExecuteDeleteAsync();

            if (affectedRows == 0)
            {
                return NotFound(); //404
            }

            return NoContent(); //204
        }
    }
}
