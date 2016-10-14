using Configurator.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configurator.Services.IServices
{
    public interface IProductService
    {
        ProductModel GetProductById (int id);
        IList<ProductModel> GetAllProducts();
        void SaveProduct(ProductModel product);
        bool UpdateProduct(ProductModel product);
        bool DeleteProduct(int id);
    }
}
