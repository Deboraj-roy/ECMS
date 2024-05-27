using ECMS.Domain.Entities;

namespace ECMS.Domain.Repositories
{
    public interface IProductRepository : IRepositoryBase<Product, int>
    { 
        Task<(IList<Product> records, int total, int totalDisplay)>
            GetTableDataAsync(string searchName, string orderBy, int pageIndex, int pageSize);
    }
}
