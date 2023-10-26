using AutoMapper;
using ProductCatalog.Storage.Entities;
using ProductCatalog.Storage.Repository;
using ProductCatalog.Domain.DataTransferObjects;

namespace ProductCatalog.Domain.Services.Implementations;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<CategoryDto> GetByIdAsync(long id)
    {
        var category = await _categoryRepository.GetByIdAsync(id);
        return _mapper.Map<CategoryDto>(category);
    }

    public async Task<IEnumerable<CategoryDto>> GetAllAsync()
    {
        var categoriesResult = await _categoryRepository.GetAllAsync();
        return categoriesResult.Select(x => new CategoryDto()
        {
            Id = x.Id,
            Name = x.Name
        });
    }

    public async Task<CategoryDto> AddAsync(CategoryDto category) =>
        await MapResult(_categoryRepository.AddAsync, category);

    public async Task<CategoryDto> UpdateAsync(CategoryDto category) =>
        await MapResult(_categoryRepository.UpdateAsync, category);

    public async Task<CategoryDto> DeleteCascadeByIdAsync(long id)
    {
        var deletedCategory = await _categoryRepository.DeleteCascadeByIdAsync(id);
        
        return new CategoryDto()
        {
            Id = deletedCategory.Id,
            Name = deletedCategory.Name
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