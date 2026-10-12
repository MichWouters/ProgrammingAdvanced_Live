using DemoProject.Models;
using DemoProject.Repos;

namespace DemoProject.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        // Specifieke repos
        private IKlantRepo _klantRepo;
        private ILaptopRepo _laptopRepo;
        private IBestellingRepo _bestellingRepo;

        // Generieke repos
        private IGenericRepo<Product> _productRepo;
        private IGenericRepo<OrderLijn> _orderlijnRepo;
        

        // Context met constructor injectie
        private DemoProjectContext _context;

        public UnitOfWork(DemoProjectContext context)
        {
            _context = context;
        }

        // Lazy loading = We gaan pas iets voorzien als het gevraagd wordt
        // In alle daaropvolgende requests geven we de bestaande repo aan.

        // Specifiek
        public ILaptopRepo LaptopRepo => _laptopRepo ?? new LaptopRepo(_context);
        public IKlantRepo KlantRepo => _klantRepo ?? new KlantRepo(_context);
        public IBestellingRepo BestellingRepo => _bestellingRepo ??= new BestellingRepo(_context);

        // Algemeen
        public IGenericRepo<Product> ProductRepository => _productRepo ??= new GenericRepo<Product>(_context);
        public IGenericRepo<OrderLijn> OrderlijnRepo => _orderlijnRepo ??= new GenericRepo<OrderLijn>(_context);


        // Zorgt voor transaction Safety -> Als er een fout tijdens een transactie zit,
        // worden alle changes terug ongedaan gemaakt.
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
