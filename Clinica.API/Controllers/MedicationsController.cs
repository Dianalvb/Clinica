using Clinica.API.Data;
using Clinica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("/api/agendas")]
    public class MedicationsController: ControllerBase
    {
        private readonly DataContext dataContext;
        public MedicationsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(Medication Medications)
        {
            dataContext.Medication.Add(Medications);
            await dataContext.SaveChangesAsync();
            return Ok(Medications);
        }
    }
}
