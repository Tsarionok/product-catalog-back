using AutoMapper;
using ProductCatalog.Storage.Entities;

namespace ProductCatalog.Domain.DataTransferObjects.Mapping;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Currency, CurrencyDto>().ReverseMap();
    }
}