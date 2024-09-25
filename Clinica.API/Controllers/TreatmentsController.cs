using Clinica.API.Data;
using Clinica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("/api/treatments")]
    public class TreatmentsController:ControllerBase
    {
        private readonly DataContext dataContext;
        public TreatmentsController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpPost]

        public async Task<IActionResult> PostAsync(Treatment Treatments)
        {
            dataContext.Treatments.Add(Treatments);
            await dataContext.SaveChangesAsync();
            return Ok(Treatments);
        }
    }
}
