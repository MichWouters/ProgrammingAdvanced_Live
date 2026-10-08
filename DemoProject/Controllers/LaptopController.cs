using DemoProject.Data;
using DemoProject.Models;
using DemoProject.Repos;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LaptopController : ControllerBase
    {
        private IUnitOfWork _uow;
        private ILogger<LaptopController> _logger;

        // Dependency Inversion (D van soliD). -> Klasse maakt zijn eigen dependencies nooit aan
        public LaptopController(IUnitOfWork uow, ILogger<LaptopController> logger)
        {
            _uow = uow;
            _logger = logger;
        }

        [HttpGet("merk")]
        public async Task<ActionResult<List<Laptop>>> GetLaptopByBrand(string merk)
        {
            List<Laptop> laptops = await _uow.LaptopRepo.GetLaptopsByBrandAsync(merk);

            if (laptops == null)
            {
                return NotFound($"Geen laptops met merk {merk} gevonden");
            }

            return Ok(laptops);
        }

        // URl/Laptop
        [HttpGet()]
        public async Task<ActionResult<Laptop[]>> GetAllLaptopsAsync()
        {
            List<Laptop> laptops = await _uow.LaptopRepo.GetAllAsync();

            if (laptops == null || laptops.Count == 0)
            {
                return NotFound("Geen laptops gevonden");
            }

            return Ok(laptops);
        }

        //Url/Laptop/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Laptop>> FindLaptopAsync(int id)
        {
            Laptop laptop = await _uow.LaptopRepo.GetByIdAsync(id);

            if (laptop == null)
            {
                return NotFound();
            }

            return Ok(laptop);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLaptop([FromBody] Laptop laptop)
        {

            laptop.Id = 0;

            _uow.LaptopRepo.Add(laptop);
            await _uow.SaveChangesAsync();

            return CreatedAtAction(nameof(CreateLaptop), new { id = laptop.Id });
        }

        // url/laptop/3
        [HttpPut("{id}")]
        public async Task<ActionResult> EditLaptopAsync(int id, [FromBody] Laptop laptop)
        {
            // Bestaande laptop ophalen
            Laptop bestaandeLaptop = await _uow.LaptopRepo.GetByIdAsync(id);

            if (bestaandeLaptop == null)
            {
                // Toon foutboodschap
                return NotFound();
            }

            // Mapping: het overzetten van data uit object A naar object B
            bestaandeLaptop.GPU = laptop.GPU;
            bestaandeLaptop.Processor = laptop.Processor;
            bestaandeLaptop.RamInGB = laptop.RamInGB;
            bestaandeLaptop.Price = laptop.Price;
            bestaandeLaptop.Merk = laptop.Merk;

            // Bestaande laptop op te slaan
            _uow.LaptopRepo.Update(bestaandeLaptop);
            await _uow.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteLaptopAsync(int id)
        {
            Laptop laptop = new Laptop { Id = id };

            try
            {
                _uow.LaptopRepo.Delete(laptop);
                await _uow.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e.StackTrace);
                return BadRequest(e.Message);
            }

            return NoContent();
        }
    }
}
