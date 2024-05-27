using Microsoft.EntityFrameworkCore;
using ECMS.Domain.Entities;
using ECMS.Domain.Repositories;
using System.Linq.Expressions;

namespace ECMS.Infrastructure.Repositories
{
    public class ProductRepository : Repository<Product, int>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            
        }

        public async Task<(IList<Product> records, int total, int totalDisplay)> 
            GetTableDataAsync(string searchName, string orderBy, int pageIndex, int pageSize)
        {
            Expression<Func<Product, bool>> expression = null;
            if(string.IsNullOrWhiteSpace(searchName))
            {
                expression = x => x.Name.Contains(searchName);
            }

            return await GetDynamicAsync(expression, orderBy, null, pageIndex, pageSize, true);
        }

    }
}
