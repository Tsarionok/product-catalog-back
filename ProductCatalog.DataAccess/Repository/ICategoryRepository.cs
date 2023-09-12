using ProductCatalog.DataAccess.Entities;

namespace ProductCatalog.DataAccess.Repository;

public interface ICategoryRepository : IRepository
{
    public Category GetById(long id);
}