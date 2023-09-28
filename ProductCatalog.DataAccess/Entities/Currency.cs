using ProductCatalog.Common;

namespace ProductCatalog.DataAccess.Entities;

public class Currency : BaseModel<long>
{
    public string Code { get; set; }
    
    public int MinorUnits { get; set; }
}