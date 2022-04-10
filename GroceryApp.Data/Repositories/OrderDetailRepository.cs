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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        private readonly AppDbContext _context;

        public OrderDetailRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }
        public void Update(OrderDetail orderDetail)
        {
            _context.OrderDetails.Update(orderDetail); 
            //var categoryDb = _context.Categories.FirstOrDefault( x => x.Id = orderDetail.Id );
            //if(categoryDb != null)
            //{
            //  categoryDb.Name = category.Name;
            //  categoryDb.DisplayOrder = category.DisplayOrder;
            //}
        }
    }
}
