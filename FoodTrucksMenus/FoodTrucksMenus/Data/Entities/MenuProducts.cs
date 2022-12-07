namespace FoodTrucksMenus.Data.Entities
{
    public class MenuProducts
    {
        public int Id { get; set; }
        public Menu Menu { get; set; }
        public Product Product { get; set; }
    }
}
