using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrucksMenus.Data.Entities
{
    public class Package
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int UsersNumber { get; set; }
        public int BranchesNumber { get; set; }
        public int MenusNumber { get; set; }
        public int TablesNumber { get; set; }
        public List<string> Detallis { get; set; }
        [Column(TypeName = "money")]
        public decimal PurchasePrice { get; set; }
    }
}
