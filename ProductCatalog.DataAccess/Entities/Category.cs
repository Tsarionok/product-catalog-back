namespace ProductCatalog.DataAccess.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}