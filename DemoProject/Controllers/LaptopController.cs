using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LaptopController: ControllerBase
    {
        // BAD PRACTICE! Controller zou nooit rechtstreek dbContext mogen aanspreken
        private DemoProjectContext _context;

        // Dependency Inversion (D van soliD). -> Klasse maakt zijn eigen dependencies nooit aan
        public LaptopController(DemoProjectContext context)
        {
            _context = context;
        }


        // URl/Laptop
        [HttpGet("{laptop}")]
        public Laptop[] GetAllLaptops(string laptop)
        {
            return _context.Laptops.ToArray();
        }

        //Url/Laptop/3
        [HttpGet("{id}")]
        public Laptop FindLaptop(int id)
        {
            return _context.Laptops.Find(id);
        }

        [HttpPost]
        public void CreateLaptop([FromBody]Laptop laptop)
        {
            // Query genereren
            _context.Laptops.Add(laptop);

            // Voer query uit
            _context.SaveChanges();
        }
    }
}
