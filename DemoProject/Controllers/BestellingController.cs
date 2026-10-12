using DemoProject.Data;
using DemoProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BestellingController : ControllerBase
    {
        private IUnitOfWork _uow;

        public BestellingController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bestelling>> GetBestellingMetKlantAsync(int id)
        {
            Bestelling? bestelling = await _uow.BestellingRepo.GetBestellingMetKlantAsync(id);

            if (bestelling == null)
            {
                return NotFound();
            }

            return Ok(bestelling);
        }

        [HttpGet("details/{id}")]
        public async Task<ActionResult<Bestelling>> GetBestellingMetAlleDetailsAsync(int id)
        {
            Bestelling? bestelling = await _uow.BestellingRepo.GetBestellingMetAlleDetailsAsync(id);

            if (bestelling == null)
            {
                return NotFound();
            }

            return Ok(bestelling);
        }
    }
}
