using FoodTrucksMenus.Data;
using FoodTrucksMenus.Data.Entities;
using FoodTrucksMenus.Helpers;
using FoodTrucksMenus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace FoodTrucksMenus.Controllers
{
    //ToDo: Crud Producto y asignar al menu de una vez
    public class ProductController : Controller
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;
        public ProductController(ICombosHelper combosHelper, DataContext context)
        {
            _context = context;
            _combosHelper = combosHelper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products
                .Include(pc => pc.Category)
                .Include(p => p.MenuProducts)
                .ThenInclude(p => p.Menu)
                .ToListAsync());
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _context.Products
                .Include(p => p.Category)
                .Include(pm => pm.MenuProducts)
                .ThenInclude(pm => pm.Menu)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        public async Task<IActionResult> Create()
        {
            CreateProductViewModel model = new()
            {
                Categories = await _combosHelper.GetComboCategoriesAsync()
            };

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                Guid imageId = Guid.Empty;
                if (model.ImageFile != null)
                {
                    //imageId = await _blobHelper.UploadBlobAsync(model.ImageFile, "products");
                }
                Product product = new()
                {
                    Description = model.Description,
                    NameProd = model.Name,
                    PriceOfert = model.PriceOfert,
                    PriceSale = model.PriceSale,
                    PurchasePrice = model.PurchasePrice,
                    PrepTime = Convert.ToInt32(60 * model.PrepTime),
                    Cant = model.Cant,
                    Category = await _context.Categories.FindAsync(model.CategoryId),
                };
                if (model.ImageFile != null)
                {

                    product.ImagenProduct = model.ImageFile.FileName;
                    Uploads(model.ImageFile);
                }
                /*
                product.ProductCategories = new List<ProductCategory>()
                {
                        new ProductCategory
                        {
                            Category = await _context.Categories.FindAsync(model.CategoryId)
                        }
                };
                if (imageId != Guid.Empty)
                {
                    product.ProductImages = new List<ProductImage>()
                    {
                               new ProductImage { ImageId = imageId }
                    };
                }*/

                try
                {
                    _context.Add(product);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException dbUpdateException)
                {
                    if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    {
                        ModelState.AddModelError(string.Empty, "Ya existe un producto con el mismo nombre.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, dbUpdateException.InnerException.Message);
                    }
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            model.Categories = await _combosHelper.GetComboCategoriesAsync();
            return View(model);
        }

        private void Uploads(IFormFile files)
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Product");
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                FileInfo fileInfo = new FileInfo(files.FileName);
                string[] fileEx = files.FileName.Split(".");
                string fileName = fileEx[0] + fileInfo.Extension;

                string fileNameWithPath = Path.Combine(path, fileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    files.CopyTo(stream);
                }

            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
            }

        }

    }
}
