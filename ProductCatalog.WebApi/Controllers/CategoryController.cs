using Microsoft.AspNetCore.Mvc;
using ProductCatalog.BusinessLogic.DataTransferObjects;
using ProductCatalog.BusinessLogic.Services;
using ProductCatalog.WebApi.ApiModels;

namespace ProductCatalog.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryService _categoryService;

    public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }

    [HttpGet("{id:long}")]
    public async Task<CategoryApiModel> GetAsync(long id)
    {
        var category = await _categoryService.GetByIdAsync(id);

        return new CategoryApiModel()
        {
            Id = category.Id,
            Name = category.Name
        };
    }
    
    [HttpGet]
    public async Task<IEnumerable<CategoryApiModel>> GetAllAsync()
    {
        var categories = await _categoryService.GetAllAsync();
        return categories.Select(x => new CategoryApiModel()
        {
            Id = x.Id,
            Name = x.Name
        });
    }

    [HttpPost]
    public async Task<CategoryApiModel> AddAsync(CategoryApiModel category)
    {
        var categoryResult = await _categoryService.AddAsync(new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name
        });
        return new CategoryApiModel()
        {
            Id = categoryResult.Id,
            Name = categoryResult.Name
        };
    }

    [HttpPut]
    public async Task<CategoryApiModel> UpdateAsync(CategoryApiModel category)
    {
        var categoryResult = await _categoryService.UpdateAsync(new CategoryDto()
        {
            Id = category.Id,
            Name = category.Name
        });
        return new CategoryApiModel()
        {
            Id = categoryResult.Id,
            Name = categoryResult.Name
        };
    }

    [HttpDelete("{id:long}")]
    public async Task<CategoryApiModel> DeleteByIdAsync(long id)
    {
        var category = await _categoryService.DeleteByIdAsync(id);

        return new CategoryApiModel()
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}