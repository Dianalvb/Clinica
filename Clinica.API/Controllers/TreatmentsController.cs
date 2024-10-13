using Clinica.API.Data;
using Clinica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("/api/treatments")]
    public class TreatmentsController : ControllerBase
    {
        private readonly DataContext dataContext;
        public TreatmentsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Treatments.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Treatments.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Treatment treatment)
        {
            dataContext.Treatments.Add(treatment);
            await dataContext.SaveChangesAsync();
            return Ok(treatment);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Treatment treatment)
        {
            dataContext.Treatments.Update(treatment);
            await dataContext.SaveChangesAsync();
            return Ok(treatment);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await dataContext.Treatments.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
