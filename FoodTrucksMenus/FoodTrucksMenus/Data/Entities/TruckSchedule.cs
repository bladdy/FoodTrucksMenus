namespace FoodTrucksMenus.Data.Entities
{
    public class TruckSchedule
    {
        public int Id { get; set; }
        public Truck? Truck { get; set; }
        public Schedule? Schedule { get; set; }
    }
}