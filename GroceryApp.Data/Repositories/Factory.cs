using GroceryApp.Data.Data;
using GroceryApp.Data.Repositories;



namespace GroceryApp.Data.Repositories
{
    public class Factory : IFactory
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
