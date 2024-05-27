using ECMS.Domain.Entities;

namespace ECMS.Application.Services
{
    public class ProductManagementService : IProductManagementService
    {
        private readonly IApplicationUnitOfWork _unitOfWork;

        public ProductManagementService(IApplicationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task CreateProductAsync(string name, string description, decimal price, string imageUrl)
        {
            Product product = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                ImageUrl = imageUrl
            };

            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveAsync(); 
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _unitOfWork.ProductRepository.GetByIdAsync(id);
        }

        public async Task<IList<Product>>? GetProductAsync()
        {
            return await _unitOfWork.ProductRepository.GetAllAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            await _unitOfWork.ProductRepository.RemoveAsync(id); 
            await _unitOfWork.SaveAsync();
        } 

        public async Task UpdateProductAsync(int id, string name, string description, decimal price, string imageUrl)
        {
            var Product = await GetProductAsync(id);
            if (Product is not null)
            {
                Product.Name = name;
                Product.Description = description;
                Product.Price = price;
                Product.ImageUrl = imageUrl;
            }

            await _unitOfWork.SaveAsync();
        }

        public async Task<(IList<Product> records, int total, int totalDisplay)> GetPagedProductsAsync(int pageIndex, int pageSize, string searchTitle, string sortBy)
        {
            return await _unitOfWork.ProductRepository.GetTableDataAsync(searchTitle, sortBy, pageIndex, pageSize);
        }
    }
}
