using Magazin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin.Controller
{
    public class TypeLogic
    {
        private ProductsContext _productsContext = new ProductsContext();
        public List<Magazin.Models.Type> GetAllTypes()
        {
        return _productsContext.Types.ToList();
        }
        public string GetTypeById(int id)

        {
            return _productsContext.Types.Find(id).Name;
        }
    }
}
