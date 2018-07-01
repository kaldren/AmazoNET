using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AmazoNET.Models;

namespace AmazoNET.ViewModels
{
    public class ProductFormViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}