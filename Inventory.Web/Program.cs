using Inventory.Utility.HelperClass;
using Inventory.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Inventory.Repository;
using Inventory.Repository.BillTypeService;
using Inventory.Models;
using Inventory.Repository.CustomerTypeService;
using Inventory.Repository.SalesTypeService;
using Inventory.Repository.InvoiceServices;
using Inventory.Repository.VendorTypeService;
using Inventory.Repository.PamentTypes;
using Inventory.Repository.Purchase;
using Inventory.Repository.ProductService;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json.Linq;
using System.Xml;
using Inventory.Web.Utilities;
using Inventory.Repository.Shipment;
using Inventory.Repository.CustomerService;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");
builder.Services.Configure<SuperAdmin>(builder.Configuration.GetSection("SuperAdmin"));
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddHealthChecks();
//builder.Services.AddAntiforgery(options =>
//{
//    options.HeaderName = "X-CSRF-TOKEN";
//    options.SuppressXFrameOptionsHeader = false;
//});

builder.Services.AddIdentity<AppUser,IdentityRole>().AddDefaultTokenProviders()
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBillTypeRepo, BillTypeRepo>();
builder.Services.AddScoped<ICustomerTypeRepo, CustomerTypeRepo>();
builder.Services.AddScoped<ISalesTypeService, SalesTypeService>();
builder.Services.AddScoped<IInvoiceTypeRepo, InvoiceTypeRepo>();
builder.Services.AddScoped<IVendorTypeRepo, VendorTypeRepo>();
builder.Services.AddScoped<IPaymentTypeRepo, PaymentTypeRepo>();
builder.Services.AddScoped<IPurchaseTypeRepo, PurchaseTypeRepo>();
builder.Services.AddScoped<IProductTypeRepo, ProductTypeRepo>();
builder.Services.AddScoped<IShipmentType, ShipmentTypeRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();


var app = builder.Build();

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
app.UseMiddleware<NotFoundMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.UseHealthChecks("/health");
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions
    {
        Predicate = check => check.Tags.Contains("ready"),
        ResponseWriter = WriteResponse
    });

    endpoints.MapHealthChecks("/health/live", new HealthCheckOptions
    {
        Predicate = check => !check.Tags.Contains("ready"),
        ResponseWriter = WriteResponse
    });

    endpoints.MapControllers();
});


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
static Task WriteResponse(HttpContext httpContext, HealthReport result)
{
    httpContext.Response.ContentType = "application/json";

    var json = new JObject(
        new JProperty("status", result.Status.ToString()),
        new JProperty("results", new JObject(result.Entries.Select(pair =>
            new JProperty(pair.Key, new JObject(
                new JProperty("status", pair.Value.Status.ToString()),
                new JProperty("description", pair.Value.Description),
                new JProperty("data", new JObject(pair.Value.Data.Select(
                    p => new JProperty(p.Key, p.Value))))))))));

    return httpContext.Response.WriteAsync(json.ToString((Newtonsoft.Json.Formatting)Formatting.Indented));
}

