using DemoProject.Data;
using DemoProject.Models;
using DemoProject.Repos;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KlantController : ControllerBase
    {
        private IUnitOfWork _uow;

        public KlantController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet("naam/{achternaam}")]
        public async Task<ActionResult<List<Klant>>> GetKlantenByLastName(string achternaam)
        {
            List<Klant> klanten = await _uow.KlantRepo.GetKlantByLastName(achternaam);

            if (klanten == null)
            {
                return NotFound();
            }

            return Ok(klanten);
        }

        [HttpGet]
        public async Task<ActionResult<List<Klant>>> GetAllKlanten()
        {
            List<Klant> klanten = await _uow.KlantRepo.GetAllAsync();

            if (klanten == null || klanten.Count == 0)
            {
                return NotFound("Geen klanten gevonden");
            }

            return Ok(klanten);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Klant>> GetKlantById(int id)
        {
            Klant klant = await _uow.KlantRepo.GetByIdAsync(id);

            if (klant == null)
            {
                return NotFound("Geen klant gevonden");
            }

            return Ok(klant);
        }

        [HttpPost]
        public async Task<ActionResult<Klant>> CreateKlant([FromBody] Klant klant)
        {
            klant.Id = 0;
            _uow.KlantRepo.Add(klant);
            await _uow.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateKlant), new { id = klant.Id });
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateKlant(int id, [FromBody] Klant updatedKlant)
        {
            if (id != updatedKlant.Id)
            {
                return BadRequest();
            }


            Klant? bestaandeKlant = await _uow.KlantRepo.GetByIdAsync(id);

            if (bestaandeKlant == null)
            {
                return NotFound();
            }

            bestaandeKlant.AchterNaam = updatedKlant.AchterNaam;
            bestaandeKlant.Voornaam = updatedKlant.Voornaam;
            bestaandeKlant.DatumAangemaakt = updatedKlant.DatumAangemaakt;
            bestaandeKlant.Bestellingen = updatedKlant.Bestellingen;

            _uow.KlantRepo.Update(bestaandeKlant);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteKlant(int id)
        {
            try
            {
                Klant bestaandeKlant = await _uow.KlantRepo.GetByIdAsync(id);

                if (bestaandeKlant == null)
                {
                    return NotFound();
                }

                _uow.KlantRepo.Delete(bestaandeKlant);
                await _uow.SaveChangesAsync();

                return NoContent();
            }
            catch(Exception ex)
            {
                //_logger.LogException(ex);
                throw;
            }
        }
    }
}
