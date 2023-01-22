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
        Task<IEnumerable<SelectListItem>> GetComboPLatformsAsync();
        Task<IEnumerable<SelectListItem>> GetComboMenuAsync(int categoryId);
        Task<IEnumerable<SelectListItem>> GetComboCountriesAsync();
        Task<IEnumerable<SelectListItem>> GetComboStatesAsync(int countryId);
        Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId);
    }
}
