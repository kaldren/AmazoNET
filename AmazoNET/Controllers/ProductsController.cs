using System.Web.Mvc;
using System.Linq;
using AmazoNET.Models;
using AmazoNET.ViewModels;

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
    }
}