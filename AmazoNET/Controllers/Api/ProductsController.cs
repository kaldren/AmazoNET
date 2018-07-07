using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AmazoNET.Models;

namespace AmazoNET.Controllers.Api
{
    public class ProductsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ProductsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult GetProduct([FromUri] int id)
        {
            var product = _context
                .Products
                .SingleOrDefault(p => p.Id == id);

            //if (product == null)
            //    return NotFound();

            //product.Remove();

            //_context.SaveChanges();

            return Ok(product.Name);
        }
    }
}
