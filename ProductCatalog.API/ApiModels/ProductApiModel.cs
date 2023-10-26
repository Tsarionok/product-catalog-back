namespace ProductCatalog.API.ApiModels;

public class ProductApiModel : BaseApiModel
{
    public required string Name { get; set; }
    
    public CategoryApiModel? Category { get; set; }
    
    public string Description { get; set; }
    
    public decimal Cost { get; set; }
    
    public string CommonNote { get; set; }
    
    public string SpecialNote { get; set; }
}

public class AddProductApiModel
{
    public required string Name { get; set; }
    
    public long CategoryId { get; set; }
    
    public string Description { get; set; }
    
    public decimal Cost { get; set; }
    
    public string CommonNote { get; set; }
    
    public string SpecialNote { get; set; }
}