using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [ValidateNever]
        [RegularExpression(@"^[A-Z][^*|\"":<>[\]{}?#`\%_()'=;@$&!]+$", ErrorMessage = "Not a valid Name!")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][^*|\"":<>[\]{}?#`\%_()'=;@$&!]+$", ErrorMessage = "Not a valid Address!")]
        public string? Address { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][^*|\"":<>[\]{}?#`\%_()'=;@$&!]+$", ErrorMessage = "Not a valid City Name!")]
        public string? City { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][^*|\"":<>[\]{}?#`\%_()'=;@$&!]+$", ErrorMessage = "Not a valid State Name!")]
        public string? State { get; set; }

        [Required]
        public string? PinCode { get; set; }
    }
}
