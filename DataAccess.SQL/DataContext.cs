using Core.Model;
using Core.ViewModel;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("sqlDBConn")
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
