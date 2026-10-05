namespace DemoProject.Models
{
    public class Product: IModel
    {
        public int Id { get; set; }

        public string Naam { get; set; }

        public string? Beschrijving { get; set; }

        public decimal Prijs { get; set; }

        public List<OrderLijn> OrderLijnen { get; set; } = default!;
    }
}
