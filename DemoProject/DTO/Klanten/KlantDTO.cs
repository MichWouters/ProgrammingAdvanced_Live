namespace DemoProject.DTO.Klanten
{
    public class KlantDTO
    {
        public int Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public DateOnly DatumAangemaakt { get; set; }
    }
}
