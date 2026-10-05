namespace DemoProject.Models
{
    // Veel op veel /associatie tabel
    public class OrderLijn: IModel
    {
        public int Id { get; set; }

        // 2 Foreign keys maken samen een veel op veel relatie
        public int BestellingId { get; set; }

        public int ProductId { get; set; }

        public int Aantal { get; set; }

        // Navigation Properties
        public Product Product { get; set; } = default!;

        public Bestelling Bestelling { get; set; } = default!;
    }
}
