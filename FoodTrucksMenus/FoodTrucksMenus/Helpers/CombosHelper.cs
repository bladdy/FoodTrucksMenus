﻿using FoodTrucksMenus.Data;
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

        public async Task<IEnumerable<SelectListItem>> GetComboCitiesAsync(int stateId)
        {
            List<SelectListItem> list = await _context.Cities
                .Where(x => x.State.Id == stateId)
                .Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = $"{x.Id}"
                })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una ciudad...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboCountriesAsync()
        {
            List<SelectListItem> list = await _context.Countries.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = $"{x.Id}"
            })
                .OrderBy(x => x.Text)
                .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un país...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboMenuAsync(int categoryId)
        {
            List<SelectListItem> list = await _context.Menus
               .Where(x => x.Category.Id == categoryId)
               .Select(x => new SelectListItem
               {
                   Text = x.Name,
                   Value = $"{x.Id}"
               })
               .OrderBy(x => x.Text)
               .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Menu...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboPLatformsAsync()
        {
            List<SelectListItem> list = await _context.Platforms.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = $"{x.Id}"
            })
               .OrderBy(x => x.Text)
               .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione una Plataforma...]",
                Value = "0"
            });
            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboProductsAsync(List<Product> filter, int MenuID)
        {
            List<Product> products = await _context.Products.Where(p => p.Category.Id == MenuID).ToListAsync();
            List<Product> productFilterd = new();
            foreach (Product product in products)
            {
                if(!filter.Any(c=>c.Id == product.Id))
                {
                    productFilterd.Add(product);
                }
            }
            List<SelectListItem> list = productFilterd.Select(c => new SelectListItem
            {
                Text = c.NameProd,
                Value = $"{c.Id}"

            })
                .OrderBy(c => c.Text)
                .ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Producto...]",
                Value = "0"
            });

            return list;
        }

        public async Task<IEnumerable<SelectListItem>> GetComboStatesAsync(int countryId)
        {
            List<SelectListItem> list = await _context.States
               .Where(x => x.Country.Id == countryId)
               .Select(x => new SelectListItem
               {
                   Text = x.Name,
                   Value = $"{x.Id}"
               })
               .OrderBy(x => x.Text)
               .ToListAsync();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un estado/provincia...]",
                Value = "0"
            });

            return list;
        }
    }
}
