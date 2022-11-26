namespace FoodTrucksMenus.Data.Entities
{
    public class TruckCategory
    {
        public int Id { get; set; }
        public Category? Category { get; set; }
        public Truck? Truck { get; set; }
    }
}