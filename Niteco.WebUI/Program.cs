using Niteco.ApplicationCore.Interfaces.IService;
using Niteco.ApplicationCore.Services;
using Niteco.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Niteco.ApplicationCore.Interfaces.IRepository;
using Niteco.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllersWithViews();

// Connection to database
builder.Services.AddDbContext<NitecoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// sau khi co cai nay co the su dung cac function co san, add claims
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<NitecoDbContext>();
// DI, doan nay em chua tao het class, nhung no se nhu nay
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Task 3: Authenticaion and Authoriztion
// doan nay se dung duong identity
app.UseAuthentication();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
