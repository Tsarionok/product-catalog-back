using ProductCatalog.BusinessLogic.DataTransferObjects;
using ProductCatalog.DataAccess.Entities;
using ProductCatalog.DataAccess.Repository;

namespace ProductCatalog.BusinessLogic.Services.Implementations;

public class CategoryService : ICategoryService
{
    private ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CategoryDto> GetByIdAsync(long id)
    {
        var category = await _repository.GetByIdAsync(id);
        
        // TODO: Include automapper
        return new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public async Task<CategoryDto> AddAsync(CategoryDto category)
    {
        var categoryResult = await _repository.AddAsync(new Category()
        {
            Id = category.Id,
            Name = category.Name
        });
        return new CategoryDto()
        {
            Id = categoryResult.Id,
            Name = categoryResult.Name
        };
    }
}