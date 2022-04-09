using GroceryApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Data.Repositories
{
    public class Factory : IUnitOfWork
    {
        private AppDbContext _context;
        public ICategoryRepository Category { get; set; }
        public IProductRepository Product { get; set; }

        //public ICartRepository Cart { get; set; }

        //public IOrderHeaderRepository OrderHeader { get; set; }

        //public IOrderDetailRepository OrderDetail { get; set; }

        public Factory(AppDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
            //Cart = new CartRepository(context);
            //ApplicationUser = new ApplicationRepository(context);
            //OrderDetails = new OrderDetailRepository(context);
            //OrderHeader = new OrderHeaderRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();   
        }

    }
}
