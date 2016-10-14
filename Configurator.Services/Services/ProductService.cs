using Configurator.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configurator.Services.ServiceModels;
using Configurator.DataLayer.IRepository;
using Configurator.DataLayer;

namespace Configurator.Services.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _productRepo;
        public ProductService (IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public bool DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ProductModel> GetAllProducts()
        {
            return _productRepo.GetAllProducts().Select(x=> new ProductModel (x)).ToList();
        }

        public ProductModel GetProductById(int id)
        {
            Product prod = _productRepo.GetProductById(id);
            ProductModel p = new ProductModel();
            p.Id = prod.Id;
            p.Name = prod.Name;
            return p;
        }

        public void SaveProduct(ProductModel product)
        {
            _productRepo.SaveProduct(product.GetRepoProduct());
        }

        public bool UpdateProduct(ProductModel product)
        {
            throw new NotImplementedException();
        }
    }
}
