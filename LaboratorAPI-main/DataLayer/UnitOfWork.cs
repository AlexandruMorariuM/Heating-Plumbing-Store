
using DataLayer.Repositories;

namespace DataLayer
{
    public class UnitOfWork
    {
        public OrderRepository Orders { get; }
        public UserRepository Users { get; }
        public ItemRepository Items { get; }

        private readonly AppDbContext _dbContext;

        public UnitOfWork
        (
            AppDbContext dbContext,
            OrderRepository orders,
            UserRepository users,
            ItemRepository items
        )
        {
            _dbContext = dbContext;
            Orders = orders ;
            Users= users;
            Items = items;
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch(Exception exception)
            {
                var errorMessage = "Error when saving to the database: "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
            }
        }
    }
}
