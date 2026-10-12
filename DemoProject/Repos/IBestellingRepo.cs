using DemoProject.Models;

namespace DemoProject.Repos
{
    public interface IBestellingRepo: IGenericRepo<Bestelling>
    {
        Task<Bestelling?> GetBestellingMetKlantAsync(int id);

        Task<Bestelling?> GetBestellingMetAlleDetailsAsync(int id);
    }
}
