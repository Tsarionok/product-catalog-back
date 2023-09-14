using Microsoft.EntityFrameworkCore;
using ProductCatalog.DataAccess.Entities;

namespace ProductCatalog.DataAccess.Context;

public class ProductCatalogContext : DbContext
{
    public ProductCatalogContext(DbContextOptions<ProductCatalogContext> options) : base(options)
    {
    }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Currency> Currencies { get; set; }
    
    public DbSet<Product> Products { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(
            "server=localhost;user=root;password=root1234;database=product_catalog;", 
            new MySqlServerVersion(new Version(8, 1, 0))
            );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildCategoryEntity(modelBuilder);
        BuildCurrencyEntity(modelBuilder);
        BuildProductEntity(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    private void BuildCategoryEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .ToTable("categories");
        
        modelBuilder.Entity<Category>()
            .Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id")
            .ValueGeneratedOnAdd();
        
        modelBuilder.Entity<Category>()
            .Property(p => p.Name)
            .IsRequired()
            .HasColumnName("name");
    }

    private void BuildCurrencyEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Currency>()
            .ToTable("currencies");
        
        modelBuilder.Entity<Currency>()
            .Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Currency>()
            .Property(p => p.Code)
            .IsRequired()
            .HasColumnName("code");

        modelBuilder.Entity<Currency>()
            .Property(p => p.MinorUnits)
            .IsRequired()
            .HasColumnName("minor_units");
    }

    private void BuildProductEntity(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .ToTable("products");
        
        modelBuilder.Entity<Product>()
            .Property(p => p.Id)
            .IsRequired()
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Product>()
            .Property(p => p.Name)
            .IsRequired()
            .HasColumnName("name");

        modelBuilder.Entity<Product>()
            .Property(p => p.Cost)
            .IsRequired()
            .HasColumnName("cost");

        modelBuilder.Entity<Product>()
            .Property(p => p.Description)
            .IsRequired(false)
            .HasColumnName("description");

        modelBuilder.Entity<Product>()
            .Property(p => p.CommonNote)
            .IsRequired(false)
            .HasColumnName("common_note");

        modelBuilder.Entity<Product>()
            .Property(p => p.SpecialNote)
            .IsRequired(false)
            .HasColumnName("special_note");
    }
}