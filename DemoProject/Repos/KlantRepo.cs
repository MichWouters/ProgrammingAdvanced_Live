using DemoProject.Data;
using DemoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repos
{
    public class KlantRepo : GenericRepo<Klant>, IKlantRepo
    {
        public KlantRepo(DemoProjectContext context) : base(context)
        {
        }

        public async Task<List<Klant>> GetKlantByLastName(string achternaam)
        {
            return await _context.Klanten
                .Where(x => x.AchterNaam == achternaam)
                .OrderBy (x => x.Voornaam)
                .ToListAsync();
        }
    }
}
