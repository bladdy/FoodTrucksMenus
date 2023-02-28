namespace FoodTrucksMenus.Data.Entities
{
    public class PackageUsers
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public Package? Package { get; set; }
        //ToDo: cambiar a tipo de datos Solo Fecha
        public DateTime? Date { get; set; }
    }
}