using FoodTrucksMenus.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using static NuGet.Packaging.PackagingConstants;

namespace FoodTrucksMenus.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string? ClienteName { get; set; }
        public Truck? Truck { get; set; }
        public Table? Table { get; set; }
        public ICollection<OrderDetail>? OrderDetails { get; set; }
        public float CantProduct => OrderDetails == null ? 0 : OrderDetails.Sum(od => od.Quantity);
        [Column(TypeName = "money")]
        public decimal TotalOrder => OrderDetails == null ? 0 : OrderDetails.Sum(od => od.Total);

       
        public StatusType StatusType { get; set; }
        public DateTime OrderDatetime { get; set; }
    }
}