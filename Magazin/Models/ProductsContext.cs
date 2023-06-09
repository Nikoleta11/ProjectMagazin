using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin.Models
{
    public class ProductsContext:DbContext
    {
        public ProductsContext() : base("ProductsContext")
        {
            
        }
        public DbSet<Product>Products { get; set; }
        public DbSet<Type>Types { get; set; }
    }
}
