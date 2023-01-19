using FoodTrucksMenus.Data;
using FoodTrucksMenus.Data.Entities;
using FoodTrucksMenus.Helpers;
using FoodTrucksMenus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace FoodTrucksMenus.Controllers
{
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
                .Include(pi => pi.ProductImages)
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
                .Include(pi => pi.ProductImages)
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
                Product product = new()
                {
                    Description = model.Description,
                    NameProd = model.Name,
                    PriceOfert = model.PriceOfert,
                    PriceSale = model.PriceSale,
                    PurchasePrice = model.PurchasePrice,
                    Truck = await _context.Trucks.FindAsync(1),
                    PrepTime = Convert.ToInt32(60 * model.PrepTime),
                    Cant = model.Cant,
                    Status = model.Status,
                    DateCreated = DateTime.Now,
                    Category = await _context.Categories.FindAsync(model.CategoryId),
                };
                
                if (model.ImageFile != null)
                {
                    product.ProductImages = new List<ProductImage>()
                    {
                               new ProductImage { ImagenProduct = model.ImageFile.FileName }
                    };
                    Uploads(model.ImageFile);
                }
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
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            CreateProductViewModel model = new()
            {
                Categories = await _combosHelper.GetComboCategoriesAsync(),
                Name = product.NameProd,
                PriceOfert = product.PriceOfert,
                PriceSale = product.PriceSale,
                PrepTime = product.PrepTime,
                PurchasePrice = product.PurchasePrice,
                Cant = product.Cant,
                Status = product.Status,
                Description = product.Description,

            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateProductViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
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
                    Status = model.Status,
                    Id = model.Id,
                    Category = await _context.Categories.FindAsync(model.CategoryId),
                };
                if (model.ImageFile != null)
                {
                    product.ProductImages = new List<ProductImage>()
                    {
                               new ProductImage { ImagenProduct = model.ImageFile.FileName }
                    };
                    Uploads(model.ImageFile);
                }
                try
                {
                    _context.Update(product);
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
        public async Task<IActionResult> AddImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            AddProductImageViewModel model = new()
            {
                ProductId = product.Id,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddImage(AddProductImageViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = await _context.Products.FindAsync(model.ProductId);
                ProductImage productImage = new()
                {
                    Product = product,
                    ImagenProduct = model.ImageFile.FileName
                };
                Uploads(model.ImageFile);
                try
                {
                    _context.Add(productImage);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Details), new { Id = product.Id });
                }
                catch (Exception exception)
                {
                    ModelState.AddModelError(string.Empty, exception.Message);
                }
            }

            return View(model);
        }
        public async Task<IActionResult> DeleteImage(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductImage productImage = await _context.ProductImages
                .Include(pi => pi.Product)
                .FirstOrDefaultAsync(pi => pi.Id == id);
            if (productImage == null)
            {
                return NotFound();
            }

            //await _blobHelper.DeleteBlobAsync(productImage.ImageId, "products");
            DeleteImg(productImage.ImageFullPath);
            _context.ProductImages.Remove(productImage);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { Id = productImage.Product.Id });
        }

        private void DeleteImg(string imageFullPath)
        {
            throw new NotImplementedException();
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
