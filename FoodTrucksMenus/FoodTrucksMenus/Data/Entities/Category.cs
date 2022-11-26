using System.ComponentModel.DataAnnotations;

namespace FoodTrucksMenus.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? NameCat { get; set; }
        public ICollection<TruckCategory>? TruckCategories { get; set; }
    }
}
