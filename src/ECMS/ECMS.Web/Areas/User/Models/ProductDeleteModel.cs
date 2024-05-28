using Autofac;
using ECMS.Application.Services;

namespace ECMS.Web.Areas.User.Models
{
    public class ProductDeleteModel
    {

        private ILifetimeScope _scope;
        private IProductManagementService _productManagementService;

        public ProductDeleteModel()
        { }
        public ProductDeleteModel(IProductManagementService productManagementService)
        {
            _productManagementService = productManagementService;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _productManagementService = _scope.Resolve<IProductManagementService>();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _productManagementService.GetProductAsync(id);
            if (product is not null)
            {
                await _productManagementService.DeleteProductAsync(id);
            }
        }
    }
}
