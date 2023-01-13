using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FoodTrucksMenus.Data.Entities
{
    public class ProductImage
    {

        public int Id { get; set; }

        public Product Product { get; set; }

        //[Display(Name = "Foto")]
        //public Guid ImageId { get; set; }
        [Display(Name = "Foto")]
        public string? ImagenProduct { get; set; }
        //TODO: Pending to change to the correct path
        [Display(Name = "Foto")]
        public string ImageFullPath => string.IsNullOrEmpty(ImagenProduct)
            ? $"https://localhost:7240/Img/noimage.png"
            : $"https://localhost:7240/Product/{ImagenProduct}";

    }
}
