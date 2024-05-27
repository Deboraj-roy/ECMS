using ECMS.Application;
using ECMS.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ECMS.Infrastructure
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IProductRepository ProductRepository { get; private set; }
        public ApplicationUnitOfWork(IProductRepository productRepository,
            IApplicationDbContext dbContext) : base((DbContext)dbContext)
        {
            ProductRepository = productRepository;
        }

    }
}
