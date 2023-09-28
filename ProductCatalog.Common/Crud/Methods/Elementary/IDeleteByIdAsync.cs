using ProductCatalog.Common.CQRS;

namespace ProductCatalog.Common.Crud.Methods.Elementary;

public interface IDeleteByIdAsync<TModel, TId> : ICommand
    where TId : struct
    where TModel : BaseModel<TId>
{
    TModel DeleteByIdAsync(TId id);
}