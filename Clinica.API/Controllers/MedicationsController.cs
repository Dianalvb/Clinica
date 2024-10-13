using Clinica.API.Data;
using Clinica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("/api/medications")]
    public class MedicationsController : ControllerBase
    {
        private readonly DataContext dataContext;
        public MedicationsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Medications.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Medications.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Medication medication)
        {
            dataContext.Medications.Add(medication);
            await dataContext.SaveChangesAsync();
            return Ok(medication);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Medication medication)
        {
            dataContext.Medications.Update(medication);
            await dataContext.SaveChangesAsync();
            return Ok(medication);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await dataContext.Medications.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
