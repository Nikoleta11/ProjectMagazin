using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Opisanie { get; set; }
        public double Price { get; set; }
        public int Srok { get; set; }
        public int TypesId { get; set; }
        public Type Types { get; set; }
    }
}
