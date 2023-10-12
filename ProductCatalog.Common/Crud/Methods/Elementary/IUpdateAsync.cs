using ProductCatalog.Common.CQRS;

namespace ProductCatalog.Common.Crud.Methods.Elementary;

public interface IUpdateAsync<TModel, TId> : ICommand 
    where TId : struct
    where TModel : BaseModel<TId>
{
    Task<TModel> UpdateAsync(TModel entity);
}