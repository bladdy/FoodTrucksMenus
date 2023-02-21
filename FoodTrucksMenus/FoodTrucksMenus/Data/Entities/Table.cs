using System.ComponentModel.DataAnnotations;

namespace FoodTrucksMenus.Data.Entities
{
    public class Table
    {
        [Key]
        public int Id { get; set; }
        public string? NameTable { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public int GuestNumber { get; set; }
        public Truck? Truck { get; set; }
        public Branch? Branch { get; set; }
        public bool? Occupied => Orders?.Where(
            o => o.StatusType == Enums.StatusType.New || 
            o.StatusType == Enums.StatusType.Open && 
            o.Table.Id == Id).Count() >= 1 ? true : false;
        public Guid? ImagenQR { get; set; }

        public string ImageFullPath => ImagenQR == Guid.Empty
            ? $"https://localhost:7059/Img/noimage.png"
            : $"https://shoppingprep.blob.core.windows.net/Tables/{ImagenQR}";
    }
}