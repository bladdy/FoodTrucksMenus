using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrucksMenus.Data.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string? NameProd { get; set; }

        public Category? Category { get; set; }
        public bool Status { get; set; }
        public bool InOfert { get; set; }

        [Column(TypeName = "money")]
        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "money")]
        public decimal PriceSale { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Display(Name = "Cantidad")]
        public decimal Cant { get; set; }
        [Display(Name = "Descripcion")]
        public string? Description { get; set; }
        public DateTime? DateCreated { get; set; }


        [Display(Name = "Foto")]
        public Guid? ImagenProduct { get; set; }
        

        //TODO: Pending to put the correct paths
        [Display(Name = "Foto")]
        public string ImageFullPath => ImagenProduct == Guid.Empty
            ? $"https://localhost:7240/Img/noimage.png"
            : $"https://localhost:7240/Product/{ImagenProduct}";
        public ICollection<MenuProducts>? MenuProducts { get; set; }
    }
}