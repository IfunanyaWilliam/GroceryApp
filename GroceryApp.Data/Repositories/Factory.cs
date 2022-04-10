using GroceryApp.Data.Data;
using GroceryApp.Data.Contracts;
using GroceryApp.Data.Repositories;



namespace GroceryApp.Data.Repositories
{
    public class Factory : IFactory
    {
        private AppDbContext _context;
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

        //public ICartRepository Cart { get; set; }

         public IOrderRepository Order { get; private set; }

        public IOrderDetailRepository OrderDetail { get; private set; }

        public Factory(AppDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(context);
            Product = new ProductRepository(context);
            //Cart = new CartRepository(context);
            //AppUser = new AppUserRepository(context);
            OrderDetail = new OrderDetailRepository(context);
            Order = new OrderRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();   
        }

    }
}
