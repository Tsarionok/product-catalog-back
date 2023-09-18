using AutoMapper;
using ProductCatalog.BusinessLogic.DataTransferObjects;

namespace ProductCatalog.WebApi.ApiModels.Mapping;

public class ApiModelsMappingProfile : Profile
{
    public ApiModelsMappingProfile()
    {
        CreateMap<CategoryDto, CategoryApiModel>().ReverseMap();
        CreateMap<ProductDto, ProductApiModel>().ReverseMap();
    }
}