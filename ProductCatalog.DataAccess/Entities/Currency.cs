namespace ProductCatalog.DataAccess.Entities;

public class Currency : BaseEntity
{
    public string Code { get; set; }
    
    public int MinorUnits { get; set; }
}