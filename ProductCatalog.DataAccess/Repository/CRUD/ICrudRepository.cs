using ProductCatalog.Common;
using ProductCatalog.Common.Crud.Methods;

namespace ProductCatalog.DataAccess.Repository.CRUD;

public interface ICrudRepository<TEntity, TId> : ICrud<TEntity, TId> 
    where TId : struct
    where TEntity : BaseModel<TId>
{
    
}