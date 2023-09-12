using ProductCatalog.BusinessLogic.DataTransferObjects;
using ProductCatalog.DataAccess.Repository;

namespace ProductCatalog.BusinessLogic.Services.Implementations;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public CategoryDto GetById(long id)
    {
        var category = _repository.GetById(id);
        
        // TODO: Include automapper
        return new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}