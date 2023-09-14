using ProductCatalog.BusinessLogic.DataTransferObjects;
using ProductCatalog.DataAccess.Entities;
using ProductCatalog.DataAccess.Repository;

namespace ProductCatalog.BusinessLogic.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<CategoryDto> GetByIdAsync(long id)
    {
        var category = await _repository.GetByIdAsync(id);
        
        return new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categoriesResult = await _repository.GetAllAsync();
        return categoriesResult.Select(x => new CategoryDto()
        {
            Id = x.Id,
            Name = x.Name
        });
    }

    public async Task<CategoryDto> AddAsync(CategoryDto category) =>
        await MapResult(_repository.AddAsync, category);

    public async Task<CategoryDto> UpdateAsync(CategoryDto category) =>
        await MapResult(_repository.UpdateAsync, category);

    public async Task<CategoryDto> DeleteByIdAsync(long id)
    {
        var category = await _repository.DeleteByIdAsync(id);
        
        return new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name
        };
    }

    private async Task<CategoryDto> MapResult(Func<Category, Task<Category>> operationAsync, CategoryDto category)
    {
        var categoryResult = await operationAsync(new Category()
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