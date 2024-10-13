using Clinica.API.Data;
using Clinica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("/api/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly DataContext dataContext;
        public PatientsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Patients.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Patients.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Patient patient)
        {
            dataContext.Patients.Add(patient);
            await dataContext.SaveChangesAsync();
            return Ok(patient);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Patient patient)
        {
            dataContext.Patients.Update(patient);
            await dataContext.SaveChangesAsync();
            return Ok(patient);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await dataContext.Patients.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
