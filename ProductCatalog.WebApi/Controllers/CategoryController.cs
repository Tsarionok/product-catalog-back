using Microsoft.AspNetCore.Mvc;
using ProductCatalog.BusinessLogic.Services;

namespace ProductCatalog.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ILogger<CategoryController> _logger;
    private readonly ICategoryService _categoryService;

    public CategoryController(ILogger<CategoryController> logger, ICategoryService categoryService)
    {
        _logger = logger;
        _categoryService = categoryService;
    }

    [HttpGet(Name = "GetCategory")]
    public Category Get(long id)
    {
        var category = _categoryService.GetById(id);

        return new Category()
        {
            Id = category.Id,
            Name = category.Name
        };
    }
}