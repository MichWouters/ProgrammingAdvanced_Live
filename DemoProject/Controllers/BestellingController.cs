using DemoProject.Data;
using DemoProject.DTO.Bestellingen;
using DemoProject.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApiDemo.DTOs.Bestellingen;

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

        [HttpPost]
        public async Task<ActionResult<BesteldProductDTO>> PostBestelling([FromBody] BestellingWriteDto dto)
        {
            // 1. Validatie -> Deze gebeurt automatisch dankzij Data Annotations in de DTO
            await ValideerBestellingAsync(dto);

            // Bij manuele validatie moeten we Modelstate tonen
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            // 2. Map Dto naar Model
            Bestelling model = dto.Adapt<Bestelling>();

            // 3. Stuur model naar UOW (repos)
            _uow.BestellingRepo.Add(model);
            await _uow.SaveChangesAsync();

            BesteldProductDTO result = new BesteldProductDTO { Id = model.Id };
            return CreatedAtAction(nameof(PostBestelling), result);
        }

        private async Task ValideerBestellingAsync(BestellingWriteDto dto)
        {
            // Bestaat de klant?
            bool klantBestaat = await _uow.KlantRepo.ExistsAsync(dto.KlantId);

            if (!klantBestaat)
            {
                ModelState.AddModelError(nameof(dto.KlantId), $"Klant met id {dto.KlantId} bestaat niet!");
            }

            // Haal alle bestaande ProductId's en vergelijk met deze met de inkomende id's zodat er geen mismatches zijn.
            int[] bestaandeProductIds = await _uow.ProductRepository.GetExistingIdsAsync();

            foreach(var lijn in dto.OrderLijnen)
            {
                if(!bestaandeProductIds.Contains(lijn.ProductId))
                {
                    ModelState.AddModelError(nameof(lijn.ProductId), $"Product met id {lijn.ProductId} bestaat niet!");
                }
            }
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
        public async Task<ActionResult<KlantMetBestellingenDTO>> GetBestellingMetAlleDetailsAsync(int id)
        {
            Bestelling? bestelling = await _uow.BestellingRepo.GetBestellingMetAlleDetailsAsync(id);

            if (bestelling == null)
            {
                return NotFound();
            }

            KlantMetBestellingenDTO dto = bestelling.Adapt<KlantMetBestellingenDTO>();

            return Ok(dto);
        }
    }
}
