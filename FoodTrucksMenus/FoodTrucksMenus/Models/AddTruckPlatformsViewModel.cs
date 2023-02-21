using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FoodTrucksMenus.Models
{
    public class AddTruckPlatformsViewModel
    {
        public int TruckId { get; set; }
        [Display(Name = "Plataforma")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Plataforma.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int PlatformsId { get; set; }

        public IEnumerable<SelectListItem> Platforms { get; set; }
    }
}
