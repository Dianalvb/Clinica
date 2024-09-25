using Clinica.API.Data;
using Clinica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

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
        [HttpPost]

        public async Task<IActionResult> PostAsync(Diagnosis Diagnoses)
        {
            dataContext.Diagnoses.Add(Diagnoses);
            await dataContext.SaveChangesAsync();
            return Ok(Diagnoses);
        }

    }
}
