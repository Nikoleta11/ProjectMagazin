using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin.Models
{
    public class Type
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public ICollection<Product>Products { get; set; }

    }
}
