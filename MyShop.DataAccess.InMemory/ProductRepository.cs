using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MyShop.Core.Models;

namespace MyShop.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products = new List<Product>();

        public ProductRepository()
        {
            products = cache["products"] as List<Product>;
            if(products == null)
            {
                products = new List<Product>();
            }
        }

        public void Comit()
        {
            cache["products"] = products;
        }

        //Insert
        public void Insert(Product p)
        {
            products.Add(p);
        }

        //update
        public void Update(Product product)
        {
            Product productToUpdte = products.Find(p => p.Id == product.Id);
            if(productToUpdte!=null)
            {
                productToUpdte = product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        //Find
        public Product Find(string Id)
        {
            Product product = products.Find(p=>p.Id==Id);
            if (product != null)
            {
                return product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        //Display or list of products
        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        //Delete

        public void Delete(string Id)
        {
            Product productToDelete = products.Find(p => p.Id == Id);
            if (productToDelete != null)
            {
                products.Remove(productToDelete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }


    }
}
