namespace DemoProject.Models
{
    public class Klant: IModel
    {
        public int Id { get; set; }

        public string AchterNaam { get; set; }

        public string Voornaam { get; set; }

        public DateOnly DatumAangemaakt { get; set; } = new DateOnly();

        // Navigation Property
        // Maak een lijst altijd aan.
        public List<Bestelling> Bestellingen { get; set; } = new List<Bestelling>();


    }
}
