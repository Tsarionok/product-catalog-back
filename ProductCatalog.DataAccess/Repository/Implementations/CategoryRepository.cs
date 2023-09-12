using ProductCatalog.DataAccess.Entities;

namespace ProductCatalog.DataAccess.Repository.Implementations;

public class CategoryRepository : ICategoryRepository
{
    public Category GetById(long id)
    {
        // TODO: remove mock data
        return new Category()
        {
            Id = 123,
            Name = "Mocked category"
        };
    }
}