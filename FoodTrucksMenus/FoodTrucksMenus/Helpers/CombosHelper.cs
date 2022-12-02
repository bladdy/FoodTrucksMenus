using FoodTrucksMenus.Data;
using FoodTrucksMenus.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace FoodTrucksMenus.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SelectListItem>> GetComboBranchesAsync(int truckId)
        {
            List<SelectListItem> list = await _context.Branches
               .Where(x => x.Truck.Id == truckId)
               .Select(x => new SelectListItem
               {
                   Text = x.NameBranch,
                   Value = $"{x.Id}"
               })
               .OrderBy(x => x.Text)
               .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una Sucursal...]",
                Value = "0"
            });

            return list;
        }
    

        public async Task<IEnumerable<SelectListItem>> GetComboCategoriesAsync()
        {
            List<SelectListItem> list = await _context.Categories.Select(x => new SelectListItem
            {
                Text = x.NameCat,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una Categoria...]",
                Value = "0"
            });

            return list;
        }
    }
}
