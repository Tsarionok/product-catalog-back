using Microsoft.EntityFrameworkCore;

using ProductCatalog.API.ApiModels.Mapping;
using ProductCatalog.Domain.DataTransferObjects.Mapping;
using ProductCatalog.Domain.Services;
using ProductCatalog.Domain.Services.Implementations;
using ProductCatalog.Storage.Context;
using ProductCatalog.Storage.Repository;
using ProductCatalog.Storage.Repository.Implementations;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ProductCatalog");
builder.Services.AddDbContext<ProductCatalogDbContext>(
    options => 
        options.UseMySql(
            connectionString, 
            new MySqlServerVersion(new Version(8, 1, 0))
    ));

builder.Services.AddAutoMapper(typeof(DtoMappingProfile), typeof(ApiModelsMappingProfile));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductCatalogDbContext, ProductCatalogDbContext>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICurrencyRepository, CurrencyRepository>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();