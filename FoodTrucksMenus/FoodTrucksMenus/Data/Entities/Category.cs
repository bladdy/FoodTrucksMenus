using System.ComponentModel.DataAnnotations;

namespace FoodTrucksMenus.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Nombre de Categoria")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? NameCat { get; set; }
        public ICollection<TruckCategory>? TruckCategories { get; set; }
    }
}
