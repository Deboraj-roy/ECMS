using Autofac;
using ECMS.Application.Services;
using ECMS.Domain.Entities;

namespace ECMS.Web.Areas.User.Models
{
    public class ProductDetailsModel
    {
        private ILifetimeScope _scope;
        private IProductManagementService _productManagementService;
        public Product product { get; set; }
        public ProductDetailsModel()
        { }
        public ProductDetailsModel(IProductManagementService productManagementService)
        { 
            _productManagementService = productManagementService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            product = await _productManagementService.GetProductAsync(id);
            return product;
        }
    }
}
