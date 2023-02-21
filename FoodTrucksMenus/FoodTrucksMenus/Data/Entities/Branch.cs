using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FoodTrucksMenus.Data.Entities
{
    public class Branch
    {
        public int Id { get; set; }
        [Display(Name = "Sucursal")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string NameBranch { get; set; }

        [Display(Name = "Telefonos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Phone { get; set; }

        [Display(Name = "Dirección")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string? Address { get; set; }
        public bool IsMain { get; set; }
        [Display(Name = "N° de Mesas")]
        public int TablesNumbers { get; set; }
        public Truck Truck { get; set; }


        [Display(Name = "Mesas Ocupadas")]
        //public int? GetOccupied => Tables == null ? 0 : Tables.Count(od => od.Occupied == true && od.Branch.Id == Id);
        public int? GetOccupied => Tables?.Count(t => t.Occupied == true && t.Branch.Id == Id);
        [Display(Name = "Cantidad de Mesas")]
        public int? CantTable => Tables?.Count(od => od.Branch.Id == Id);
        //1 a muchos
        public ICollection<Menu>? Menus { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<Table>? Tables { get; set; }
        [Display(Name = "Ciudad")]
        public City City { get; set; }
    }
}
