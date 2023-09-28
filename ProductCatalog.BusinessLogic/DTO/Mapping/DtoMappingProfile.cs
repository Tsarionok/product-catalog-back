using AutoMapper;
using ProductCatalog.DataAccess.Entities;

namespace ProductCatalog.BusinessLogic.DataTransferObjects.Mapping;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        CreateMap<Category, CategoryDto>().ReverseMap();
        CreateMap<Product, ProductDto>().ReverseMap();
        CreateMap<Currency, CurrencyDto>().ReverseMap();
    }
}