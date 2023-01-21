using FoodTrucksMenus.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace FoodTrucksMenus.Models
{
    public class AddOrEditBranchViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public string Name { get; set; }
        [Display(Name = "Telefonos")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public string Phone { get; set; }
        [Display(Name = "Dirección")]
        [MaxLength(200, ErrorMessage = "El campo {0} debe tener máximo {1} caractéres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]

        public string Address { get; set; }
        public bool IsMain { get; set; }
        [Display(Name = "Numero de Mesas")]
        public int TablesNumbers { get; set; }
        public Truck Truck { get; set; }

        [Display(Name = "País")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un país.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int CountryId { get; set; }

        public IEnumerable<SelectListItem> Countries { get; set; }

        [Display(Name = "Estado / Provincia")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar un Estado / Provincia.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public int StateId { get; set; }

        public IEnumerable<SelectListItem> States { get; set; }

        [Display(Name = "Ciuadad")]
        [Range(1, int.MaxValue, ErrorMessage = "Debes de seleccionar una ciudad.")]
        public int CityId { get; set; }

        public IEnumerable<SelectListItem> Cities { get; set; }
    }
}
