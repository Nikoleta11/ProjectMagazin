using Magazin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Magazin.Controller
{
    public class ProductLogic
    {
        private ProductsContext  _productsContext = new ProductsContext();  
        public Product Get(int Id) 
        
        {
            Product findedProduct = _productsContext.Products.Find(Id);
            if (findedProduct != null) 
            {
                _productsContext.Entry(findedProduct).Reference(X => X.Types).Load();
            }
            return findedProduct;

        }
        public List<Product> GetAll()
        { 
        return _productsContext.Products.Include("Types").ToList();

        }
        public void Create(Product product)
        {
            _productsContext.Products.Add(product);
            _productsContext.SaveChanges();

        }
        public void Update(int id,Product product) 
        
        {
        Product findedProduct= _productsContext.Products.Find(id);
            if (findedProduct != null) 
            {
                return;
            }
            findedProduct.Id = id;
            findedProduct.Price = product.Price;
            findedProduct.Srok=product.Srok;
            findedProduct.Marka=product.Marka;
            findedProduct.Opisanie=product.Opisanie;
            findedProduct.Types=product.Types;
        }

        public void Delete(int id) 
        
        {
        Product findedProduct=_productsContext.Products.Find(id);
            _productsContext.Products.Remove(findedProduct);
            _productsContext.SaveChanges();
        }
    }
}
