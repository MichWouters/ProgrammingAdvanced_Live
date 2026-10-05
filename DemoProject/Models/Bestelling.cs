namespace DemoProject.Models
{
    public class Bestelling: IModel
    {
        public int Id { get; set; }

        // Foreign key naar tabel / model Klant
        public int KlantId { get; set; }

        // Navigation Property
        public Klant Klant { get; set; }

        // TODO: Orderlijnen toevoegen
        public List<OrderLijn> Orderlijnen{ get; set; }
    }
}
