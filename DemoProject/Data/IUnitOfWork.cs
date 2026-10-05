using DemoProject.Models;
using DemoProject.Repos;

namespace DemoProject.Data
{
    public interface IUnitOfWork
    {
        IGenericRepo<Bestelling> BestellingRepository { get; }
        IKlantRepo KlantRepo { get; }
        ILaptopRepo LaptopRepo { get; }
        IGenericRepo<OrderLijn> OrderlijnRepo { get; }
        IGenericRepo<Product> ProductRepository { get; }

        Task<int> SaveChangesAsync();
    }
}