using System.ComponentModel.DataAnnotations;

namespace FoodTrucksMenus.Data.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public Product? Product { get; set; }
        public Order? Order { get; set; }
        public decimal? PriceUnit => Product?.PriceSale;
        public float Quantity { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Valor")]
        public decimal Total => Product == null ? 0 : (decimal)Quantity * Product.PriceSale;
        public bool Delivered { get; set; }
    }
}