using System.Web.Mvc;
using System.Linq;
using AmazoNET.Models;
using AmazoNET.ViewModels;
using AmazoNET.ViewModels.AccountViewModels;
using AmazoNET.ViewModels.ProductViewModels;
using Microsoft.AspNet.Identity;

namespace AmazoNET.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Products
        public ActionResult Create()
        {
            var viewModel = new ProductFormViewModel
            {
                Categories = _context.Categories.ToList()
            };

            return View(viewModel);
        }
         
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("Create", viewModel);
            }

            var product = new Product
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Price = viewModel.Price,
                CategoryId = viewModel.Category,
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Update(int id)
        {
            var product = _context.Products.SingleOrDefault(p => p.Id == id);

            var viewModel = new ProductFormViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Categories = _context.Categories.ToList(),
                Category = product.CategoryId
            };

            return View("Update", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(ProductFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Categories = _context.Categories.ToList();
                return View("Update", viewModel);
            }

            var product = new Product
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                Description = viewModel.Description,
                CategoryId = viewModel.Category
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}