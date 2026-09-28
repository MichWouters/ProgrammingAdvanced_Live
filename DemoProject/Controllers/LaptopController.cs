using DemoProject.Data;
using DemoProject.Models;
using DemoProject.Repos;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LaptopController: ControllerBase
    {
        private ILaptopRepo _repo;
        private ILogger<LaptopController> _logger;

        // Dependency Inversion (D van soliD). -> Klasse maakt zijn eigen dependencies nooit aan
        public LaptopController(ILaptopRepo repo, ILogger<LaptopController> logger)
        {
            _repo = repo;
            _logger = logger;
        }


        // URl/Laptop
        [HttpGet()]
        public async Task<ActionResult<Laptop[]>> GetAllLaptopsAsync()
        {
            List<Laptop> laptops = await _repo.GetObjectsAsync();

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
            Laptop laptop = await _repo.GetObjectAsync(id);

            if (laptop == null)
            {
                return NotFound();
            }

            return Ok(laptop);
        }

        [HttpPost]
        public ActionResult CreateLaptop([FromBody]Laptop laptop)
        {

            laptop.Id = 0;

            _repo.AddObject(laptop);

            return CreatedAtAction("","");
        }

        // url/laptop/3
        [HttpPut("{id}")]
        public ActionResult EditLaptop(int id, [FromBody]Laptop laptop)
        {
            // Bestaande laptop ophalen
            Laptop bestaandeLaptop = _repo.GetObjectAsync(id);

            if (bestaandeLaptop == null)
            {
                // Toon foutboodschap
            }

            // Mapping: het overzetten van data uit object A naar object B
            bestaandeLaptop.GPU = laptop.GPU;
            bestaandeLaptop.Processor = laptop.Processor;
            bestaandeLaptop.RamInGB = laptop.RamInGB;
            bestaandeLaptop.Price = laptop.Price;
            bestaandeLaptop.Merk = laptop.Merk;

            // Bestaande laptop op te slaan
            _repo.UpdateObject(bestaandeLaptop);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteLaptop(int id)
        {
            Laptop laptop = new Laptop { Id = id };

            try
            {
                _repo.DeleteObject(id);
            }
            catch(Exception e)
            {
                _logger.LogError(e.StackTrace);
                return BadRequest(e.Message);
            }

            return NoContent();
        }
    }
}
