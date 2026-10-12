using DemoProject.Data;
using DemoProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProject.Repos
{
    public class BestellingRepo: GenericRepo<Bestelling>, IBestellingRepo
    {
        public BestellingRepo(DemoProjectContext context) : base(context)
        {
        }

        public async Task<Bestelling?> GetBestellingMetKlantAsync(int id)
        {
            Bestelling? bestelling = await _context.Set<Bestelling>()
                                            .Include(x => x.Klant)
                                            .FirstOrDefaultAsync(x => x.Id == id);

            return bestelling;
        }

        public async Task<Bestelling?> GetBestellingMetAlleDetailsAsync(int id)
        {
            Bestelling? bestelling =
                await _context.Set<Bestelling>()

                //1. Haal gekoppelde klant op (Bestelling -> Klant)
                .Include(x => x.Klant)

                //2. Haal gekoppelde Orderlijnen op
                .Include(x => x.Orderlijnen)
                    .ThenInclude(o => o.Product)

                //3. Voer query uit
                .FirstOrDefaultAsync(x => x.Id == id);

            return bestelling;
        }
    }
}
