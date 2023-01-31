using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FoodTrucksMenus.Models
{
    public class AddTableViewModel
    {
        [Display(Name = "N° Comensales")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una Producto.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int GuestNumber { get; set; }
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Name { get; set; }
        public int BranchId { get; set; }
        public int TruckId { get; set; }
    }
}
