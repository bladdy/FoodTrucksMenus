namespace FoodTrucksMenus.Data.Entities
{
    public class Menu
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Category? Category { get; set; }
        public ICollection<Product>? Products { get; set; }
        public Truck? Truck { get; set; }
        public bool? Enable { get; set; }
    }
}