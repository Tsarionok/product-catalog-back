using ProductCatalog.DataAccess.Entities;

namespace ProductCatalog.DataAccess.Repository.CRUD.Implementations;

public class CategoryRepository : ICrudRepository<Category, long>
{
    public Category AddAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Category> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Category GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Category UpdateAsync(Category entity)
    {
        throw new NotImplementedException();
    }

    public Category DeleteByIdAsync(long id)
    {
        throw new NotImplementedException();
    }
}