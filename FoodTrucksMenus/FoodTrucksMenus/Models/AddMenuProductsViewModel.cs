using FoodTrucksMenus.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FoodTrucksMenus.Models
{
    public class AddMenuProductsViewModel
    {
        public int MenuId { get; set; }
        [Display(Name = "Producto")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Doctor.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int ProductId { get; set; }

        public IList<Product> Products { get; set; }
        //public IEnumerable<SelectListItem> Products { get; set; }
    }
}
