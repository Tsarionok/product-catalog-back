using ProductCatalog.Common.CQRS;

namespace ProductCatalog.Common.Crud.Methods.Elementary;

public interface IGetAllAsync<TModel, TId> : IQuery 
    where TId : struct
    where TModel : BaseModel<TId>
{
    IEnumerable<TModel> GetAllAsync();
}