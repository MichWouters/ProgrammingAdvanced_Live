namespace DemoProject.DTO.Bestellingen
{
    public class KlantMetBestellingenDTO
    {
        public int BestellingId { get; set; }

        public string VolledigeNaam { get; set; }

        public DateTime DatumBestelling { get; set; }

        public decimal TotaalPrijs { get; set; }

        public BesteldProductDTO[] BesteldeProducten { get; set; } = [];

    }
}
