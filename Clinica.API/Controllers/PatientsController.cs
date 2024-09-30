using Clinica.API.Data;
using Clinica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("/api/patients")]
    public class PatientsController:ControllerBase
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
        [HttpPost]
        public async Task<IActionResult> PostAsync(Patient Patients)
        {
            dataContext.Patients.Add(Patients);
            await dataContext.SaveChangesAsync();
            return Ok(Patients);
        }
    }
}
