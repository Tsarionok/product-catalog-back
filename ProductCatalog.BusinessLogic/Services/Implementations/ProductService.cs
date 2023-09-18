using AutoMapper;
using ProductCatalog.BusinessLogic.DataTransferObjects;
using ProductCatalog.DataAccess.Entities;
using ProductCatalog.DataAccess.Repository;

namespace ProductCatalog.BusinessLogic.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ProductDto> GetByIdAsync(long id)
    {
        var productResult = await _repository.GetByIdAsync(id);
        return _mapper.Map<ProductDto>(productResult);
    }

    public async Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var productsResult = await _repository.GetAllAsync();
        return _mapper.Map<IEnumerable<ProductDto>>(productsResult);
    }

    public async Task<ProductDto> AddAsync(ProductDto product)
    {
        var productResult = await _repository.AddAsync(_mapper.Map<Product>(product));
        return _mapper.Map<ProductDto>(productResult);
    }

    public async Task<ProductDto> UpdateAsync(ProductDto product)
    {
        var productResult = await _repository.UpdateAsync(_mapper.Map<Product>(product));
        return _mapper.Map<ProductDto>(productResult);
    }

    public async Task<ProductDto> DeleteByIdAsync(long id)
    {
        var productResult = await _repository.DeleteByIdAsync(id);
        return _mapper.Map<ProductDto>(productResult);
    }
}