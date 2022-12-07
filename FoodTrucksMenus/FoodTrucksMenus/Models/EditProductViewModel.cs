using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrucksMenus.Models
{
    public class EditProductViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Descripción")]
        [MaxLength(500, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Description { get; set; }
        [Display(Name = "Categoría")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes seleccionar una categoría.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CategoryId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        [Display(Name = "Foto")]
        public IFormFile? ImageFile { get; set; }
        [Display(Name = "Tiempo de Preparación en min")]
        public decimal PrepTime { get; set; }
        [Display(Name = "Estado")]
        public bool Status { get; set; }
        [Display(Name = "En Oferta")]
        public bool InOfert { get; set; }
        [Column(TypeName = "money")]
        [Display(Name = "Precio de Costo")]
        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "money")]
        [Display(Name = "Precio de Venta")]
        public decimal PriceSale { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        [Display(Name = "Cantidad")]
        public decimal Cant { get; set; }
        [Column(TypeName = "money")]
        [Display(Name = "Precio de Oferta")]
        public decimal PriceOfert { get; set; }

    }
}
