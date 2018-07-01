using System.Collections.Generic;
using AmazoNET.Models;

namespace AmazoNET.ViewModels
{
    public class ProductFormViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Category { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}