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
        [Display(Name = "Activo")]
        public bool Status { get; set; }
        [Display(Name = "En Oferta")]
        public bool InOfert { get; set; }

        [Column(TypeName = "money")]
        public decimal PurchasePrice { get; set; }

        [Column(TypeName = "money")]
        public decimal PriceSale { get; set; }
        [Column(TypeName = "money")]
        public decimal PriceOfert { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Display(Name = "Cantidad")]
        public decimal Cant { get; set; }
        [Display(Name = "Tiempo de Preparación")]
        public int PrepTime { get; set; }
        [Display(Name = "Descripcion")]
        public string? Description { get; set; }
        [Display(Name = "Fecha de Creacion")]
        public DateTime? DateCreated { get; set; }
        public Truck Truck { get; set; }
        public ICollection<MenuProducts>? MenuProducts { get; set; }
        [Display(Name = "Menu")]
        public int MenuNmber => MenuProducts == null ? 0 : MenuProducts.Count;
        [Display(Name = "Tiempo de Preparación en minutos")]
        public int PrepMins => PrepTime / 60;
        public ICollection<ProductImage>? ProductImages { get; set; }

        [Display(Name = "Fotos")]
        public int ImagesNumber => ProductImages == null ? 0 : ProductImages.Count;

        [Display(Name = "Foto")]
        public string ImageFullPath => ProductImages == null || ProductImages.Count == 0
            ? $"https://localhost:7240/Img/noimage.png"
            : ProductImages.FirstOrDefault().ImageFullPath;
    }
}