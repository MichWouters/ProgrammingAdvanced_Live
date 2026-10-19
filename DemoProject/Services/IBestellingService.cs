using DemoProject.DTO.Bestellingen;

namespace DemoProject.Services
{
    public interface IBestellingService
    {
        decimal BerekenKorting(decimal totaalPrijs, decimal kortingPercentage);
        BestellingCreatedDto Calculate(List<BesteldProductDTO> producten, int accountLeeftijd);
    }
}