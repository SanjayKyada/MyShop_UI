using Core.Model;
using Data.Model;
using System.Data.Entity;

namespace DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("sqlDBConn")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

    }
}
