using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Models
{
    public class Product
    { 
        public int Id { get; set; }
        
        [Required]
        [RegularExpression(@"^[A-Z][^*|\"":<>[\]{}?#`\%_()'=;@$&!]+$", ErrorMessage ="Not a valid Product Name!")]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required]
        public double Price { get; set; }
        
        [ValidateNever]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        
        [ValidateNever]
        [RegularExpression(@"^[A-Z][^*|\"":<>[\]{}?#`\%_()'=;@$&!]+$", ErrorMessage = "Not a valid Category Name!")]
        public Category Category { get; set; }
    }
}
