using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cacheObj = MemoryCache.Default;
        List<Product> products;

        //basic initization for product list and cache.
        public ProductRepository()
        {
            products = cacheObj["Products"] as List<Product>;
            if (products == null)
            { 
                products = new List<Product>();
            }
        }
        // Updating cache with object list.
        public void Commit()
        {
            cacheObj["Products"] = products;
        }

        // to get single product
        public Product GetProductDetail(string Id)
        {
            return IsProduct(Id);
        }

        //Add product in list/database.
        public void InsertProduct(Product product)
        {
            products.Add(product);
            Commit();
        }

        public void UpdateProduct(Product product)
        {
            Product oldProduct = IsProduct(product.PID);
            oldProduct.Category = product.Category;
            oldProduct.Description = product.Description;
            oldProduct.Image = product.Image;
            oldProduct.Name = product.Name;
            oldProduct.Price = product.Price;
            Commit();
        }

        //get all products.
        public IQueryable<Product> GetAllProduct()
        {
            return products.AsQueryable();
        }

        //Delete Product.
        public void DeleteProduct(string Id)
        {
            Product product = IsProduct(Id);
            products.Remove(product);
            Commit();
        }

        // for retrieving the product.
        public Product IsProduct(string productID)
        {
            Product product = products.SingleOrDefault(x => x.PID == productID);
            if (product != null)
                return product;
            else
                throw new Exception("Product not found in list.");
        }
    }
}
