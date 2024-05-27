using ECMS.Domain.Entities;

namespace ECMS.Application.Services
{
    public interface IProductManagementService
    {
        Task CreateProductAsync(string name, string description, decimal price, string imageUrl);
        Task DeleteProductAsync(int id); 
        Task<Product> GetProductAsync(int id);
        Task UpdateProductAsync(int id, string name, string description, decimal price, string imageUrl);
        Task<(IList<Product> records, int total, int totalDisplay)>
            GetPagedProductsAsync(int pageIndex, int pageSize, string searchTitle,
            string sortBy);
        Task<IList<Product>>? GetProductAsync();
    }
}
