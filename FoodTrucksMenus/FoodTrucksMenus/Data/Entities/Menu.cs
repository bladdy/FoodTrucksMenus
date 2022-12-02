using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FoodTrucksMenus.Data.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Name { get; set; }
        public Category? Category { get; set; }
        public ICollection<Product>? Products { get; set; }

        [Display(Name = "# de Productos")]
        public int CantProduct => Products == null ? 0 : Products.Count(p=>p.Category.Id == Category.Id);
        public Branch? Branch { get; set; }
        [Display(Name = "Disponible")]
        public bool? Enable { get; set; }
    }
}