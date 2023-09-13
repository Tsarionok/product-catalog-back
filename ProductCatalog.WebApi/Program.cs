using ProductCatalog.BusinessLogic.Services;
using ProductCatalog.BusinessLogic.Services.Implementations;
using ProductCatalog.DataAccess.Context;
using ProductCatalog.DataAccess.Repository;
using ProductCatalog.DataAccess.Repository.Implementations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ProductCatalogContext>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

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