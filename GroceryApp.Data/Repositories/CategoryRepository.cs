using GroceryApp.Data.Data;
using GroceryApp.Data.Contracts;
using GroceryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            var categoryDb = _context.Categories.FirstOrDefault(x => x.Id == category.Id);
            if(categoryDb != null)
            {
                categoryDb.Name = category.Name;
                categoryDb.DisplayOrder = category.DisplayOrder;
            }
        }
    }
}
