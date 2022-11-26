using Microsoft.EntityFrameworkCore;

namespace FoodTrucksMenus.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
