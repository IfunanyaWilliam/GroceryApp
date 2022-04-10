using GroceryApp.Models;
using GroceryApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Data.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
