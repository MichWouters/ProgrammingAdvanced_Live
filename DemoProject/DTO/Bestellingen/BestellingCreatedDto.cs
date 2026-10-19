namespace DemoProject.DTO.Bestellingen
{
    public class BestellingCreatedDto
    {
        public decimal TotaalPrijs { get; set; }

        public bool HeeftVipGoodieBag { get; set; }

        public decimal VerzendKosten { get; set; }

        public List<BesteldProductDTO> ProductenInBestelling { get; set; }
    }
}
