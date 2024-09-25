using Clinica.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.API.Controllers
{
    [ApiController]
    [Route("/api/agendas")]
    public class AgendasController
    {
        private readonly DataContext dataContext;
        public AgendasController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
    }
}
