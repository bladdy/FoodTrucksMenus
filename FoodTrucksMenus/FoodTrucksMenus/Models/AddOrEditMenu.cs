using FoodTrucksMenus.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace FoodTrucksMenus.Models
{
    public class AddOrEditMenu
    {
        
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Name { get; set; }
        [Display(Name = "Categoria")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Categoria.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        [Display(Name = "Sucursal")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Sucursal.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int TruckId { get; set; }
        [Display(Name = "Disponible")]
        public bool Enable { get; set; }
    }
}
