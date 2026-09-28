using DemoProject.Models;

namespace DemoProject.Repos
{
    public interface ILaptopRepo
    {
        Task AddObjectAync(Laptop laptop);
        void DeleteObject(int id);
        Task<Laptop> GetObjectAsync(int id);
        Task<List<Laptop>> GetObjectsAsync();
        void UpdateObject(Laptop laptop);
    }
}