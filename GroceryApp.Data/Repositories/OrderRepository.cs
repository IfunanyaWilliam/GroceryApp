using GroceryApp.Data.Data;
using GroceryApp.Models;
using GroceryApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Data.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void PaymentStatus(int Id, string SessionId, string paymentIntentId)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == Id);
            order.DateOfPayment = DateTime.Now;
            order.PaymentIntentId = paymentIntentId;
            order.SessionId = SessionId;
        }

        public void Update(Order order)
        {
            _context.Orders.Update(order);
            //var categoryDb = _context.Categories.FirstOrDefault(x => x.Id == order.Id);
            //if(categoryDb != null)
            //{
            //  categoryDb.Name = category.Name;
            //  categoryDb.DisplayOrder = category.DisplayOrder;
            //}

        }

        public void UpdateStatus(int Id, string orderStatus, string? paymentStatus)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == Id);
            if(order != null)
            {
                order.OrderStatus = orderStatus;
            }

            if(paymentStatus != null)
            {
                order.PaymentStatus = paymentStatus;
            }
            
        }
    }
}
