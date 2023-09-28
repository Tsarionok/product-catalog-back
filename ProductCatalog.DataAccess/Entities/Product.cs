using ProductCatalog.Common;

namespace ProductCatalog.DataAccess.Entities;

public class Product : BaseModel<long>
{
    public string Name { get; set; }
    
    public Category Category { get; set; }
    
    public long? CategoryId { get; set; }
    
    public string Description { get; set; }
    
    public decimal Cost { get; set; }
    
    public string CommonNote { get; set; }
    
    public string SpecialNote { get; set; }
}