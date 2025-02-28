using System.Configuration;
using Ecommerces.Entity;
using Ecommerces.Services;
using Microsoft.EntityFrameworkCore;
using static Ecommerces.Services.RegisterTblService;
//using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSession();

builder.Services.AddDbContext<EntityDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("dbcon")
));

builder.Services.AddScoped<ICategoryTblService, CategoryTblService>();
builder.Services.AddScoped<ISubCategoryTblService, SubCategoryTblService>();
builder.Services.AddScoped<IThierdCategoryTblServicescs, ThierdCategoryTblServicescs>();
builder.Services.AddScoped<IBrandTblService, BrandTblService>();
builder.Services.AddScoped<ISpecificationsTblService, SpecificationsTblService>();
builder.Services.AddScoped<ISpecificationsOptionsTblService, SpecificationsOptionsTblService>();
builder.Services.AddScoped<IProductTblService, ProductTblService>();
builder.Services.AddScoped<IRegisterTblService, RegisterTblService>();

var app = builder.Build();
app.UseSession();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomeIndex}/{action=HOMEIndex}/{id?}");

app.Run();
