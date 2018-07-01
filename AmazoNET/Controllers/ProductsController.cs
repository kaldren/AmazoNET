using System.Linq;
using System.Web.Mvc;
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
    }
}