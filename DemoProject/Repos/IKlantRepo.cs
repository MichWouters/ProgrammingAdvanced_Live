using DemoProject.Models;

namespace DemoProject.Repos
{
    public interface IKlantRepo: IGenericRepo<Klant>
    {
        Task<List<Klant>> GetKlantByLastName(string achternaam);
    }
}
