using Clinica.API.Data;
using Clinica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("/api/medications")]
    public class MedicationsController: ControllerBase
    {
        private readonly DataContext dataContext;
        public MedicationsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(Medication Medication)
        {
            dataContext.Medications.Add(Medication);
            await dataContext.SaveChangesAsync();
            return Ok(Medication);
        }
    }
}
