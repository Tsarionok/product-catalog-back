using Microsoft.EntityFrameworkCore;
using ProductCatalog.DataAccess.Entities;

namespace ProductCatalog.DataAccess.Context;

public class ProductCatalogContext : DbContext
{
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Currency> Currencies { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "server=localhost;user=root;password=root1234;database=product_catalog;", 
            new MySqlServerVersion(new Version(8, 1, 0))
            );
    }
}