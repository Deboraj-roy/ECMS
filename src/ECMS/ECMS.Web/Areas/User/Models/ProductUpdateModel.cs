using Autofac;
using ECMS.Application.Services;
using ECMS.Domain.Entities;
using Microsoft.CodeAnalysis;

namespace ECMS.Web.Areas.User.Models
{
    public class ProductUpdateModel
    {
        private ILifetimeScope _scope;
        private IProductManagementService _productManagementService;
        public Product product { get; set; }

        public ProductUpdateModel()
        { }
        public ProductUpdateModel(IProductManagementService productManagementService)
        {
            _productManagementService = productManagementService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _productManagementService = _scope.Resolve<IProductManagementService>();
        }

        public async Task<Product> LoadProductAsync(int id)
        {
            return await _productManagementService.GetProductAsync(id);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await _productManagementService.UpdateProductAsync(product.Id, product.Name, product.Description, product.Price, product.ImageUrl);
        }
    }
}
