using AutoMapper;
using ProductCatalog.Domain.DataTransferObjects;

namespace ProductCatalog.API.ApiModels.Mapping;

public class ApiModelsMappingProfile : Profile
{
    public ApiModelsMappingProfile()
    {
        CreateMap<CategoryDto, CategoryApiModel>().ReverseMap();
        CreateMap<ProductDto, ProductApiModel>().ReverseMap();
        CreateMap<AddProductApiModel, AddProductDto>().ReverseMap();
        CreateMap<CurrencyApiModel, CurrencyDto>().ReverseMap();
        CreateMap<AddCurrencyApiModel, CurrencyDto>().ReverseMap();
    }
}