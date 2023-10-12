using ProductCatalog.Common.CQRS;

namespace ProductCatalog.Common.Crud.Methods.Elementary;

public interface IAddAsync<TModel, TId> : ICommand 
    where TId : struct 
    where TModel : BaseModel<TId>
{
    Task<TModel> AddAsync(TModel entity);
}