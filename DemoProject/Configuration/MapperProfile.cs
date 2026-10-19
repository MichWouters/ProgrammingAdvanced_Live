using DemoProject.DTO.Bestellingen;
using DemoProject.DTO.Klanten;
using DemoProject.Models;
using Mapster;

namespace DemoProject.Configuration
{
    public class MapperProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            // Hier schrijven we expliciete mappings
            // ENKEL VOOR PROPERTIES DIE NIET 1 OP 1 overeenkomen
            config.NewConfig<Klant, KlantDTO>()
                .Map(dest => dest.FirstName, src => src.Voornaam)
                .Map(dest => dest.LastName, src => src.AchterNaam);

            config.NewConfig<OrderLijn, BesteldProductDTO>()
                .Map(dest => dest.Id, src => src.Product.Id)
                .Map(dest => dest.Naam, src => src.Product.Naam)
                .Map(dest => dest.Prijs, src => src.Product.Prijs)
                .Map(dest => dest.Aantal, src => src.Aantal);

            config.NewConfig<Bestelling, KlantMetBestellingenDTO>()
                .Map(dest => dest.BestellingId, src => src.Id)
                .Map(dest => dest.VolledigeNaam, src => $"{src.Klant.Voornaam} {src.Klant.AchterNaam}")
                .Map(dest => dest.TotaalPrijs, src => src.Orderlijnen.Sum(ol => ol.Aantal * ol.Product.Prijs))
                .Map(dest => dest.BesteldeProducten, src => src.Orderlijnen);
        }
    }
}
