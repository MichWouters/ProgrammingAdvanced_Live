using System.ComponentModel.DataAnnotations;

namespace DemoProject.DTO.Producten
{
    public class ProductWriteDto
    {
        [Required(ErrorMessage = "ProductNaam is verplicht")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Naam moet tussen 3 en 100 karakters zijn")]
        public string Naam { get; set; }

        [MaxLength(500, ErrorMessage = "Maximum 500 karakters")]
        public string? Beschrijving { get; set; }

        [Required(ErrorMessage = "Prijs is verplicht")]
        [Range(0.01, 10000, ErrorMessage = "De prijs moet tussen 0,01 en 10.000 euro liggen")]
        public decimal Prijs { get; set; }
    }
}
