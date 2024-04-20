using Entrega2.PGPIC.API.Data;
using Entrega2.PGPIC.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entrega2.PGPIC.API.Controllers
{
    [Route("api/researchprojects")]
    [ApiController]
    public class ResearchProjectController : ControllerBase
    {
        private readonly PGPICContext _context;

        public ResearchProjectController(PGPICContext context)
        {
            _context = context;
        }

        //Metodo Get por lista--- Select * From ResearchProjects
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.ResearchProjects.ToListAsync());
        }

        //Metodo post' Guardar registros
        [HttpPost]
        public async Task<ActionResult> Post(ResearchProject researchProject)
        {
            _context.ResearchProjects.Add(researchProject);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Metodo Get por parametro' Select * From ResearchProjects
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var ResearchProject = await _context.ResearchProjects.FirstOrDefaultAsync(x => x.Id == id);
            if (ResearchProject == null)
            {
                return NotFound(ResearchProject); //404
            }

            return Ok(ResearchProject);
        }

        //Metodo Put - Actualizar registros

        [HttpPut]
        public async Task<ActionResult> Put(ResearchProject researchProject)
        {
            _context.ResearchProjects.Update(researchProject);
            await _context.SaveChangesAsync();
            return Ok(researchProject);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.ResearchProjects
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
