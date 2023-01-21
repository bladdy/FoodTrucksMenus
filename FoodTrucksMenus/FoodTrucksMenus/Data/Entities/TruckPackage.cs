using System.ComponentModel.DataAnnotations;

namespace FoodTrucksMenus.Data.Entities
{
    public class TruckPackage
    {
        [Key]
        public int Id { get; set; }
        public Truck Truck { get; set; }
        public Package Package { get; set; }
        public DateTime Date { get; set; }
        public DateTime NextPayment { get; set; }
        public int PaidDay => Date.Day;
        public bool IsPaid => NextPayment <= DateTime.Now;
    }
}
