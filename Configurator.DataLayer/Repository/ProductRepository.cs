using Configurator.DataLayer.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.DataLayer.Repository
{

    public class ProductRepository : IProductRepository
    {
        ProductConfiguratorEntities db = new ProductConfiguratorEntities();

        public bool DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAllProducts()
        {
            return db.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return db.Products.FirstOrDefault(x => x.Id == id);
        }

        public void SaveProduct(Product product)
        {

            db.Products.Add(product);
            db.SaveChanges();
        }

        public bool UpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
