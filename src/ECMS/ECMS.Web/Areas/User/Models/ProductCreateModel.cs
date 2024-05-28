using Autofac;
using ECMS.Application.Services;

namespace ECMS.Web.Areas.User.Models
{
    public class ProductCreateModel
    {
        private ILifetimeScope _scope;
        private IProductManagementService _productManagementService;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = "https://i.ibb.co/KxryJ9H/image.png";

        public ProductCreateModel(IProductManagementService productManagementService)
        {
            _productManagementService = productManagementService;
        }
        public ProductCreateModel()
        {
        }

        internal void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _productManagementService = _scope.Resolve<IProductManagementService>();
        }

        internal async Task CreateProductAsync()
        {
            await _productManagementService.CreateProductAsync(Name, Description, Price, ImageUrl);
        }
    }
}
