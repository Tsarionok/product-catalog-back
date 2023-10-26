using ProductCatalog.Common;

namespace ProductCatalog.Storage.Entities;

public class Category : BaseModel<long>
{
    public string Name { get; set; }
    
    public ICollection<Product> Products { get; set; }
}