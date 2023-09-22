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
    private readonly IProductService _service;
    private readonly IMapper _mapper;

    public ProductController(IProductService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }
    
    [HttpGet("{id:long}")]
    public async Task<ProductApiModel> GetAsync(long id)
    {
        var productResult = await _service.GetByIdAsync(id);
        return _mapper.Map<ProductApiModel>(productResult);
    }

    [HttpGet]
    public async Task<IEnumerable<ProductApiModel>> GetAsync()
    {
        var productsResult = await _service.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductApiModel>>(productsResult);
    }

    [HttpPost]
    public async Task<ProductApiModel> AddAsync(AddProductApiModel product)
    {
        var productResult = await _service.AddAsync(_mapper.Map<AddProductDto>(product));
        return _mapper.Map<ProductApiModel>(productResult);
    }
}