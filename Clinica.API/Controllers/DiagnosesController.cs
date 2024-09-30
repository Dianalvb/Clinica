using Clinica.API.Data;
using Clinica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("/api/diagnoses")]
    public class DiagnosesController: ControllerBase
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
        [HttpPost]
        public async Task<IActionResult> PostAsync(Diagnosis Diagnoses)
        {
            dataContext.Diagnoses.Add(Diagnoses);
            await dataContext.SaveChangesAsync();
            return Ok(Diagnoses);
        }

    }
}
