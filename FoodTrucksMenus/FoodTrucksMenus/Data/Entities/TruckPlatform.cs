using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodTrucksMenus.Data.Entities
{
    public class TruckPlatform
    {
        public int Id { get; set; }
        public Truck? Truck { get; set; }
        public Platform? Platform { get; set; }
    }
}