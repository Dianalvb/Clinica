using Clinica.API.Data;
using Clinica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("/api/consults")]
    public class ConsultsController : ControllerBase
    {
        private readonly DataContext dataContext;
        public ConsultsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Consults.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Consults.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Consult consult)
        {
            dataContext.Consults.Add(consult);
            await dataContext.SaveChangesAsync();
            return Ok(consult);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Consult consult)
        {
            dataContext.Consults.Update(consult);
            await dataContext.SaveChangesAsync();
            return Ok(consult);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await dataContext.Consults.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
