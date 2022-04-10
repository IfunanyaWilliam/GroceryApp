using GroceryApp.Data.Contracts;
using GroceryApp.Data.Data;
using GroceryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context)
        {
            _context = context; 
        }

        public void Update(Product product)
        {
            var productDb = _context.Products.FirstOrDefault(x => x.Id == product.Id);
            if(productDb != null)
            {
                productDb.Name = product.Name;
                productDb.Description = product.Description;
                productDb.Price = product.Price;
                if(product.ImageUrl != null)
                {
                    productDb.ImageUrl = product.ImageUrl; 
                }
            }
        }

    }
}
