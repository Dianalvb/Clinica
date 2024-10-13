using Clinica.API.Data;
using Clinica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("/api/agendas")]
    public class AgendasController : ControllerBase
    {
        private readonly DataContext dataContext;
        public AgendasController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Agendas.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Agendas.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Agenda agenda)
        {
            dataContext.Agendas.Add(agenda);
            await dataContext.SaveChangesAsync();
            return Ok(agenda);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Agenda agenda)
        {
            dataContext.Agendas.Update(agenda);
            await dataContext.SaveChangesAsync();
            return Ok(agenda);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await dataContext.Agendas.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

