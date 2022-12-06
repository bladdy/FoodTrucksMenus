using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FoodTrucksMenus.Models
{
    public class CreateProductViewModel : EditProductViewModel
    {
        [Display(Name = "Menu")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Menu.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int MenuId { get; set; }

        public IEnumerable<SelectListItem> Menus { get; set; }
    }
}
