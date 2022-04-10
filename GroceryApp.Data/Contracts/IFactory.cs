﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GroceryApp.Data.Repositories
{
    public interface IFactory 
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get;  }
        //ICartRepository Cart {get; }
        //IApplicationUser ApplicationUser { get; }
        //IOrderHeaderRepository OrderHeader { get; }
        //IOrderDetailRepository OrderDetail { get; }

        void Save();
    }
}
