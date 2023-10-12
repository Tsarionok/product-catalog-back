using ProductCatalog.Common.Crud.Methods.Elementary;

namespace ProductCatalog.Common.Crud.Methods;

public interface ICrudAsync<TModel, TId> : 
    IAddAsync<TModel, TId>, 
    IGetAllAsync<TModel, TId>, 
    IGetByIdAsync<TModel, TId>, 
    IUpdateAsync<TModel, TId>, 
    IDeleteByIdAsync<TModel, TId> 
    where TId : struct
    where TModel : BaseModel<TId>
{
    
}