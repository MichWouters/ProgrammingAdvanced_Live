using DemoProject.Data;
using DemoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repos
{
    public class LaptopRepo : ILaptopRepo
    {
        private DemoProjectContext _context;

        public LaptopRepo(DemoProjectContext context)
        {
            _context = context;
        }

        public async Task AddObjectAync(Laptop laptop)
        {
            // Query genereren
            await _context.Laptops.AddAsync(laptop);
        }

        public void UpdateObject(Laptop laptop)
        {
            _context.Laptops.Attach(laptop);
        }

        public void DeleteObject(int id)
        {
            Laptop laptop = new Laptop { Id = id };

            _context.Remove(laptop);
        }

        public async Task<Laptop> GetObjectAsync(int id)
        {
            Laptop laptop = await _context.Laptops.FindAsync(id);
            return laptop;
        }

        public async Task<List<Laptop>> GetObjectsAsync()
        {
            List<Laptop> laptops = await _context.Laptops.ToListAsync();
            return laptops;
        }


    }
}
