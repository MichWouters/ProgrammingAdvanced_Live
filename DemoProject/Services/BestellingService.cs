using DemoProject.DTO.Bestellingen;

namespace DemoProject.Services
{
    public class BestellingService : IBestellingService
    {
        private const int MINIMUMAANTALGOODIEBAG = 10;
        private const decimal STANDAARDVERZENDKOSTEN = 25.00m;
        private const decimal DREMPELGRATISVERZENDING = 100.00m;

        public decimal BerekenKorting(decimal totaalPrijs, decimal kortingPercentage)
        {
            throw new NotImplementedException();
        }

        public BestellingCreatedDto Calculate(List<BesteldProductDTO> producten, int accountLeeftijd)
        {
            decimal totaalAfgerond = producten.Sum(x => x.Aantal * x.Prijs);
            decimal verzendKosten = BerekenVerzendKosten(totaalAfgerond);

            return new BestellingCreatedDto
            {
                ProductenInBestelling = producten,
                VerzendKosten = verzendKosten,
                TotaalPrijs = totaalAfgerond + verzendKosten,
                HeeftVipGoodieBag = HeeftVipGoodieBag(producten),
            };
        }

        private decimal BerekenVerzendKosten(decimal totaalAfgerond)
        {
            if (totaalAfgerond > DREMPELGRATISVERZENDING)
            {
                return 0.00m;
            }

            return STANDAARDVERZENDKOSTEN;
        }

        private bool HeeftVipGoodieBag(List<BesteldProductDTO> producten)
        {
            return producten.Any(x => x.Aantal > MINIMUMAANTALGOODIEBAG);
        }
    }
}
