using Microsoft.EntityFrameworkCore;
using ProductCatalog.BusinessLogic.DataTransferObjects.Mapping;
using ProductCatalog.BusinessLogic.Services;
using ProductCatalog.BusinessLogic.Services.Implementations;
using ProductCatalog.DataAccess.Context;
using ProductCatalog.DataAccess.Repository;
using ProductCatalog.DataAccess.Repository.Implementations;
using ProductCatalog.WebApi.ApiModels.Mapping;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
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