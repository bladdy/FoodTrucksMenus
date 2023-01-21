using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrucksMenus.Data.Entities
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } // Gratis, Modesto, Mediano, y Grande
        public int UsersNumber { get; set; }// minimo 1 , 2 , 4, 8 usuario por sucursal
        public int BranchesNumber { get; set; } //minimo 1 , 2 , 4 , 8 sucursal
        public int MenusNumber { get; set; } // minimo 1, 6, 9 , 12 por sucursal
        public int TablesNumber { get; set; } // minimo 1, 6  , 9 , 12 por sucursal
        public List<string> Detallis { get; set; }
        [Column(TypeName = "money")]
        public decimal PurchasePrice { get; set; }
    }
}
