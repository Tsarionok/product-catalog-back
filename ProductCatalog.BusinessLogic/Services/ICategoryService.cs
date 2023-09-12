using ProductCatalog.BusinessLogic.DataTransferObjects;

namespace ProductCatalog.BusinessLogic.Services;

public interface ICategoryService : IService
{
    public CategoryDto GetById(long id);
}