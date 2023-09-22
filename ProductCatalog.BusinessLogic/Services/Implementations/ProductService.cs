using AutoMapper;
using ProductCatalog.BusinessLogic.DataTransferObjects;
using ProductCatalog.DataAccess.Entities;
using ProductCatalog.DataAccess.Repository;

namespace ProductCatalog.BusinessLogic.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper, ICategoryService categoryService)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _categoryService = categoryService;
    }

    public async Task<ProductDto> GetByIdAsync(long id)
    {
        var productResult = await _productRepository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(productResult);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var productsResult = await _productRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(productsResult);
    }

    public async Task<ProductDto> AddAsync(AddProductDto product)
    {
        var productEntity = new Product()
        {
            Name = product.Name,
            CategoryId = product.CategoryId,
            CommonNote = product.CommonNote,
            Cost = product.Cost,
            Description = product.Description,
            SpecialNote = product.SpecialNote
        };
        var productResult = await _productRepository.AddAsync(productEntity);
        return _mapper.Map<ProductDto>(productResult);
    }

    public async Task<ProductDto> UpdateAsync(ProductDto product)
    {
        var productResult = await _productRepository.UpdateAsync(_mapper.Map<Product>(product));
        return _mapper.Map<ProductDto>(productResult);
    }

    public async Task<ProductDto> DeleteByIdAsync(long id)
    {
        var productResult = await _productRepository.DeleteByIdAsync(id);
        return _mapper.Map<ProductDto>(productResult);
    }
}