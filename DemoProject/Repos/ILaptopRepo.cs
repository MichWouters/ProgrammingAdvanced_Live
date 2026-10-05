using DemoProject.Models;

namespace DemoProject.Repos
{
    public interface ILaptopRepo: IGenericRepo<Laptop>
    {
        // We voegen enkel specifieke methodes toe
        // Generieke CRUD zitten al in de Base class
        Task<List<Laptop>> GetLaptopsByBrandAsync(string merk);
    }
}