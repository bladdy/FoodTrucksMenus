using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrucksMenus.Data.Entities
{
    public class Platform
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? IconLogo { get; set; }
        public string ImageFullPath => IconLogo == String.Empty
            ? $"https://localhost:7059/Img/noimage.png"
            : $"https://localhost:7059/Platform/{IconLogo}";
        public ICollection<TruckPlatform>? TruckPlatforms { get; set; }
    }
}