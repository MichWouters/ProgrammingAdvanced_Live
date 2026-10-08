using DemoProject.Data;
using DemoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repos
{
    public class LaptopRepo : GenericRepo<Laptop>, ILaptopRepo
    {
         public LaptopRepo(DemoProjectContext context)
            :base(context)
        {
            
        }

        public async Task<List<Laptop>> GetLaptopsByBrandAsync(string merk)
        {
            return await _context.Laptops
                .Where(x => x.Merk == merk)
                .ToListAsync();
        }
    }
}
