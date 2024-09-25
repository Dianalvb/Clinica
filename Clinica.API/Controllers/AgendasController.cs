using Clinica.API.Data;
using Clinica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("/api/agendas")]
    public class AgendasController : ControllerBase
    {
        private readonly DataContext dataContext;
        public AgendasController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpPost]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await dataContext.Agendas.ToListAsync());
        }

        public async Task <IActionResult> PostAsync (Agenda Agendas)
        {
            dataContext.Agendas.Add(Agendas);
            await dataContext.SaveChangesAsync();
            return Ok(Agendas);
        }
    }
}

