namespace ProductCatalog.WebApi.ApiModels;

public class CurrencyApiModel : BaseApiModel
{
    public string Code { get; set; }
    
    public int MinorUnits { get; set; }
}

public class AddCurrencyApiModel
{
    public required string Code { get; set; }
    
    public int MinorUnits { get; set; }
}