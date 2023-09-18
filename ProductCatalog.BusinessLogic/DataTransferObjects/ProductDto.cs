namespace ProductCatalog.BusinessLogic.DataTransferObjects;

public class ProductDto : BaseDto
{
    public required string Name { get; set; }
    
    public CategoryDto Category { get; set; }
    
    public string Description { get; set; }
    
    public decimal Cost { get; set; }
    
    public string CommonNote { get; set; }
    
    public string SpecialNote { get; set; }
}