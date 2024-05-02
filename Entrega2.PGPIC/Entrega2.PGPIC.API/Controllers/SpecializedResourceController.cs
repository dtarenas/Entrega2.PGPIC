using Entrega2.PGPIC.API.Data;
using Entrega2.PGPIC.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entrega2.PGPIC.API.Controllers
{
    [Route("api/specializedresource")]
    [ApiController]
    public class SpecializedResourceController : ControllerBase
    {
        private readonly PGPICContext _context;

        public SpecializedResourceController(PGPICContext context)
        {
            _context = context;
        }

        //Metodo Get por lista--- Select * From SpecializedResources
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.SpecializedResources.ToListAsync());
        }

        //Metodo post' Guardar registros
        [HttpPost]
        public async Task<ActionResult> Post(SpecializedResource specializedResource)
        {
            if (await _context.SpecializedResources.AnyAsync(x => x.Name.ToUpper() == specializedResource.Name.ToUpper()))
            {
                return BadRequest($"Specialized Resource with name: {specializedResource.Name} already exists");
            }

            _context.SpecializedResources.Add(specializedResource);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Metodo Get por parametro' Select * From SpecializedResources
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var SpecializedResource = await _context.SpecializedResources.FirstOrDefaultAsync(x => x.Id == id);
            if (SpecializedResource == null)
            {
                return NotFound(SpecializedResource); //404
            }

            return Ok(SpecializedResource);
        }

        //Metodo Put - Actualizar registros

        [HttpPut]
        public async Task<ActionResult> Put(SpecializedResource specializedResource)
        {
            if (!await _context.SpecializedResources.AnyAsync(x => x.Id == specializedResource.Id))
            {
                return NotFound();
            }
            _context.SpecializedResources.Update(specializedResource);
            await _context.SaveChangesAsync();
            return Ok(specializedResource);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var affectedRows = await _context.SpecializedResources
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
