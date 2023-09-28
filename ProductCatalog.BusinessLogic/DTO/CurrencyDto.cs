namespace ProductCatalog.BusinessLogic.DataTransferObjects;

public class CurrencyDto : BaseDto
{
    public string Code { get; set; }
    
    public int MinorUnits { get; set; }
}