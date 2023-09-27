using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductCatalog.BusinessLogic.DataTransferObjects;
using ProductCatalog.BusinessLogic.Services;
using ProductCatalog.WebApi.ApiModels;

namespace ProductCatalog.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    
    [HttpGet("{id:long}")]
    public async Task<ProductApiModel> GetAsync(long id)
    {
        var productResult = await _productService.GetByIdAsync(id);
        return _mapper.Map<ProductApiModel>(productResult);
    }

    [HttpGet]
    public async Task<IEnumerable<ProductApiModel>> GetAsync()
    {
        var productsResult = await _productService.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductApiModel>>(productsResult);
    }

    [HttpPost]
    public async Task<ProductApiModel> AddAsync(AddProductApiModel product)
    {
        var productResult = await _productService.AddAsync(_mapper.Map<AddProductDto>(product));
        return _mapper.Map<ProductApiModel>(productResult);
    }

    [HttpDelete]
    public async Task<ProductApiModel> DeleteAsync(long id)
    {
        var deletedProduct = await _productService.DeleteByIdAsync(id);
        return _mapper.Map<ProductApiModel>(deletedProduct);
    }
}