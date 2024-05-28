using Autofac;
using ECMS.Application.Services;
using ECMS.Domain.Entities;
using ECMS.Infrastructure;

namespace ECMS.Web.Areas.User.Models
{
    public class ProductListModel
    {
        private ILifetimeScope _scope;
        private IProductManagementService _productManagementService;
        public string ProductName { get; set; }
        public ProductListModel()  { }
        public ProductListModel(IProductManagementService productManagementService)
        {
            _productManagementService = productManagementService;
        }
        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _productManagementService = _scope.Resolve<IProductManagementService>();
        }
        public async Task<object> GetPageProductAsync(DataTablesAjaxRequestUtility dataTablesAjaxRequestUtility)
        {
            var data = await _productManagementService.GetPagedProductsAsync(
                dataTablesAjaxRequestUtility.PageIndex,
                dataTablesAjaxRequestUtility.PageSize,
                ProductName,
                dataTablesAjaxRequestUtility.GetSortText(new string[] { "Id", "Name", "Description", "Price", "ImageUrl" }));
            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Id.ToString(),
                                record.Name,
                                record.Description,
                                record.Price.ToString(),
                                record.ImageUrl
                        }).ToArray()
            };
        }

        public async Task<IList<Product>> GetAllProductAsync()
        {
            return await _productManagementService.GetProductAsync();
        }
    }
}
