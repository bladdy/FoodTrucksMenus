using System.ComponentModel.DataAnnotations;

namespace FoodTrucksMenus.Models
{
    public class AddorEditPlatformViewModel
    {
        [Display(Name = "Nombre de la plataforma")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Name { get; set; }
        [Display(Name = "Icono/Logo de la plataforma")]
        public IFormFile? IconLogo { get; set; }
    }
}
