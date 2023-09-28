using ProductCatalog.Common.CQRS;

namespace ProductCatalog.Common.Crud.Methods.Elementary;

public interface IGetByIdAsync<TModel, TId> : IQuery 
    where TId : struct
    where TModel : BaseModel<TId>
{
    TModel GetByIdAsync(TId id);
}