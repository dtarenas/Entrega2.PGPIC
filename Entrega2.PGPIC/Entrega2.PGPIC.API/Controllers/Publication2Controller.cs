using Entrega2.PGPIC.API.Data;
using Entrega2.PGPIC.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entrega2.PGPIC.API.Controllers
{
    [Route("api/publications2")]
    [ApiController]
    public class Publication2Controller : ControllerBase
    {
        private readonly PGPICContext _context;

        public Publication2Controller(PGPICContext context)
        {
            _context = context;
        }

        //Metodo Get por lista--- Select * From Publications
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Publications.Include(x => x.Project).ToListAsync());
        }

        //Metodo post' Guardar registros
        [HttpPost]
        public async Task<ActionResult> Post(Publication publication)
        {
            if (await _context.Publications.AnyAsync(x => x.Title.ToUpper() == publication.Title.ToUpper()
                && x.ProjectId == publication.ProjectId))
            {
                return BadRequest($"Publication with title: {publication.Title} and Project Name {publication.Project.Name} already exists");
            }

            _context.Publications.Add(publication);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Metodo Get por parametro' Select * From Publications
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var Publication = await _context.Publications.FirstOrDefaultAsync(x => x.Id == id);
            if (Publication == null)
            {
                return NotFound(Publication); //404
            }

            return Ok(Publication);
        }

        //Metodo Put - Actualizar registros

        [HttpPut]
        public async Task<ActionResult> Put(Publication publication)
        {
            if (!await _context.Publications.AnyAsync(x => x.Id == publication.Id))
            {
                return NotFound();
            }

            _context.Publications.Update(publication);
            await _context.SaveChangesAsync();
            return Ok(publication);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.Publications
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