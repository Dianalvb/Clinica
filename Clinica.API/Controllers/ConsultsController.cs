using Clinica.API.Data;
using Clinica.Shared.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.API.Controllers
{       [ApiController]
        [Route("/api/consults")]
    public class ConsultsController :ControllerBase
    {
            private readonly DataContext dataContext;
            public ConsultsController(DataContext dataContext)
            {
                this.dataContext = dataContext;
            }
            [HttpPost]

            public async Task<IActionResult> PostAsync(Consult Consults)
            {
                dataContext.Consults.Add(Consults);
                await dataContext.SaveChangesAsync();
                return Ok(Consults);
            }
        }
    }
