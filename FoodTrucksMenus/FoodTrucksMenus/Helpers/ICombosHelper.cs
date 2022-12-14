using FoodTrucksMenus.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace FoodTrucksMenus.Helpers
{
    public interface ICombosHelper
    {
        Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetComboBranchesAsync(int truckId);
        Task<IEnumerable<SelectListItem>> GetComboProductsAsync(List<Product> filter, int MenuID);
        Task<IEnumerable<SelectListItem>> GetComboMenuAsync(int categoryId);
    }
}
