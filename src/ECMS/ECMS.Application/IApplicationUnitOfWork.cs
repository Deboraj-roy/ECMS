using ECMS.Domain;
using ECMS.Domain.Repositories;

namespace ECMS.Application
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IProductRepository ProductRepository { get; }

    }
}
