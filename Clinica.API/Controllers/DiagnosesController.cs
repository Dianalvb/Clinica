using Clinica.API.Data;
using Clinica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("/api/diagnoses")]
    public class DiagnosesController : ControllerBase
    {
        private readonly DataContext dataContext;
        public DiagnosesController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Diagnoses.ToListAsync());
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            return Ok(await dataContext.Diagnoses.FirstOrDefaultAsync(x => x.Id == id));
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync(Diagnosis diagnosis)
        {
            dataContext.Diagnoses.Add(diagnosis);
            await dataContext.SaveChangesAsync();
            return Ok(diagnosis);
        }
        [HttpPut]
        public async Task<ActionResult> Put(Diagnosis diagnosis)
        {
            dataContext.Diagnoses.Update(diagnosis);
            await dataContext.SaveChangesAsync();
            return Ok(diagnosis);
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var afectedRows = await dataContext.Diagnoses.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (afectedRows == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
