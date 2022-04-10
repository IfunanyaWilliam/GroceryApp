using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceryApp.Data.Repositories;


namespace GroceryApp.Data.Contracts
{
    public interface IFactory 
    {
        ICategoryRepository Category { get; }
        IProductRepository Product { get;  }
        //ICartRepository Cart {get; }
        //IAppUser AppUser { get; }
        IOrderRepository Order { get; }
        //IOrderDetailRepository OrderDetail { get; }

        void Save();
    }
}
