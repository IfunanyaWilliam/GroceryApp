using GroceryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Data.Repositories
{
    public interface IOrder : IRepository<Order>
    {
        void Update(IOrder order);
        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
        void PaymentStatus(int id, string sessionId, string paymentIntentId);
    }
}
