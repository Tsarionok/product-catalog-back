using ProductCatalog.Common;
using ProductCatalog.Common.Crud.Methods;

namespace ProductCatalog.Storage.Repository.CRUD;

public interface ICrudRepositoryAsync<TEntity, TId> : ICrudAsync<TEntity, TId> 
    where TId : struct
    where TEntity : BaseModel<TId>
{
    
}