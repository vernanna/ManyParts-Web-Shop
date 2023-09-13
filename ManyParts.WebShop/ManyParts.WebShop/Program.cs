using ManyParts.WebShop.Api;
using ManyParts.WebShop.Application;
using ManyParts.WebShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<ProductsController>();
builder.Services.AddScoped<CartsController>();
builder.Services.AddScoped<DatabaseContext>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ICartsRepository, CartsRepository>();
builder.Services.AddScoped<IGetProductsUseCase, GetProductsUseCase>();
builder.Services.AddScoped<IGetCartUseCase, GetCartUseCase>();
builder.Services.AddScoped<IAddProductToCartUseCase, AddProductToCartUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

using (var scope = app.Services.CreateScope())
{
    var databaseContext = scope.ServiceProvider.GetService<DatabaseContext>();
    databaseContext!.Database.EnsureDeleted();
    databaseContext.Database.EnsureCreated();
}

app.Run();