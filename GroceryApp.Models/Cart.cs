using GroceryApp.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Data.ViewModels
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        [ValidateNever]
        public Product Product { get; set; }
        
        [ValidateNever]
        public string AppUserId { get; set; }
        
        [ValidateNever]
        public AppUser AppUser { get; set; }

        public int Count { get; set; }
    }
}
