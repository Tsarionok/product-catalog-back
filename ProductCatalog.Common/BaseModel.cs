namespace ProductCatalog.Common;

public abstract class BaseModel<T> where T : struct
{
    public T Id { get; set; }
}