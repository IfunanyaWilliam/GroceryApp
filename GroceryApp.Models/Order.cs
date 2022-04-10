﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string AppUserId { get; set; }

        [ValidateNever]
        public AppUser AppUser { get; set; }

        [Required]
        public DateTime DateOfOrder { get; set; }
        public DateTime DateOfShipping { get; set; }
        public double OrderTotal { get; set; }

        public string? OrderStatus { get; set; }

        public string? PaymentStatus { get; set; }

        public string TrackingNumber { get; set; }

        public string? Carrier { get; set; }

        public string? SessionId { get; set; }

        public string? PaymentIntentId { get; set; }

        public DateTime DateOfPayment { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string PostalCode { get; set; }

        public string Name { get; set; }

    }
}
