using DemoProject.Models;
using DemoProject.Repos;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KlantController: ControllerBase
    {
        private IKlantRepo _repo;

        public KlantController(IKlantRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("naam/{achternaam}")]
        public async Task<ActionResult<List<Klant>>> GetKlantenByLastName(string achternaam)
        {
            List<Klant> klanten = await _repo.GetKlantByLastName(achternaam); 

            if(klanten == null)
            {
                return NotFound();
            }

            return Ok(klanten);
        }

        [HttpGet]
        public async Task<ActionResult<List<Klant>>> GetAllKlanten()
        {
            List<Klant> klanten = await _repo.GetAllAsync();

            if (klanten == null || klanten.Count == 0)
            {
                return NotFound("Geen klanten gevonden");
            }

            return Ok(klanten);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Klant>> GetKlantById(int id)
        {
            Klant klant = await _repo.GetByIdAsync(id);

            if (klant == null)
            {
                return NotFound("Geen klant gevonden");
            }

            return Ok(klant);
        }
    }
}
