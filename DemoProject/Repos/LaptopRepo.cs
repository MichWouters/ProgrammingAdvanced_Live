using DemoProject.Data;
using DemoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repos
{
    public class LaptopRepo : GenericRepo<Laptop>, ILaptopRepo
    {
        private DemoProjectContext _context;

        public LaptopRepo(DemoProjectContext context)
            :base(context)
        {
            
        }
    }
}
