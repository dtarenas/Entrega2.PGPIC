using Entrega2.PGPIC.API.Data;
using Entrega2.PGPIC.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entrega2.PGPIC.API.Controllers
{
    [Route("api/researchactivities")]
    [ApiController]
    public class ResearchActivityController : ControllerBase
    {
        private readonly PGPICContext _context;

        public ResearchActivityController(PGPICContext context)
        {
            _context = context;
        }

        //Metodo Get por lista--- Select * From ResearchActivities
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.ResearchActivities.ToListAsync());
        }

        //Metodo post' Guardar registros
        [HttpPost]
        public async Task<ActionResult> Post(ResearchActivity researchActivity)
        {
            if (await _context.ResearchActivities.AnyAsync(x => x.Name.ToUpper() == researchActivity.Name.ToUpper()))
            {
                return BadRequest($"Research Activity with name: {researchActivity.Name} already exists");
            }

            _context.ResearchActivities.Add(researchActivity);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Metodo Get por parametro' Select * From ResearchActivities
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var ResearchActivity = await _context.ResearchActivities.FirstOrDefaultAsync(x => x.Id == id);
            if (ResearchActivity == null)
            {
                return NotFound(ResearchActivity); //404
            }

            return Ok(ResearchActivity);
        }

        //Metodo Put - Actualizar registros

        [HttpPut]
        public async Task<ActionResult> Put(ResearchActivity researchActivity)
        {
            if (!await _context.ResearchActivities.AnyAsync(x => x.Id == researchActivity.Id))
            {
                return NotFound();
            }

            _context.ResearchActivities.Update(researchActivity);
            await _context.SaveChangesAsync();
            return Ok(researchActivity);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.ResearchActivities
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
