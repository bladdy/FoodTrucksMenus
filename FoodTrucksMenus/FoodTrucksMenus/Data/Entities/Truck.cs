namespace FoodTrucksMenus.Data.Entities
{
    public class Truck
    {
        public int Id { get; set; }
        public string? Nametruck { get; set; }        
        public bool? Delivery { get; set; }
        public bool? Whatsapp { get; set; }
        //1 a muchos
        public ICollection<Branch>? Branch { get; set; }

        //Muchos a muchos
        public ICollection<TruckPlatform>? TruckPlatforms { get; set; }
        public ICollection<TruckCategory>? TruckCategories { get; set; }
        public ICollection<TruckSchedule>? TruckSchedules { get; set; }

        public string? ImagenLogo { get; set; }

        public string ImageFullPath => ImagenLogo == String.Empty
            ? $"https://localhost:7059/Img/noimage.png"
            : $"https://localhost:7059/Trucks/{ImagenLogo}";
    }
}
