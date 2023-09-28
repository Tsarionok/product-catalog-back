using ProductCatalog.Common.CQRS;

namespace ProductCatalog.Common.Crud.Methods.Elementary;

public interface IUpdateAsync<TModel, TId> : ICommand 
    where TId : struct
    where TModel : BaseModel<TId>
{
    TModel UpdateAsync(TModel entity);
}