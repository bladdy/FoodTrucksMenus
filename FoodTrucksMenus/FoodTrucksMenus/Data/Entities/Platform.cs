using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrucksMenus.Data.Entities
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nombre de la plataforma")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public string? Name { get; set; }
        [Display(Name = "Icono/Logo de la plataforma")]
        public string? IconLogo { get; set; }
        [Display(Name = "Icono/Logo")]
        public string ImageFullPath => string.IsNullOrEmpty(IconLogo)
            ? $"https://localhost:7240/Img/noimage.png"
            : $"https://localhost:7240/Platform/{IconLogo}";
        public ICollection<TruckPlatform>? TruckPlatforms { get; set; }
    }
}