using Microsoft.EntityFrameworkCore;
using GroceryApp.Data.Data;
using GroceryApp.Data.Repositories;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add a Service for EntityFrameworkCore. 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<AppDbContext>();


//Add service for the factory
builder.Services.AddScoped<IFactory, Factory>();
builder.Services.AddScoped<IRoleInit, RoleInitRepositry>();

//Add Razor Page
builder.Services.AddRazorPages();

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

SeedData();
app.UseAuthentication();
app.UseAuthorization();

//Add RazorPage Map
app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();

//Set up the authentication class
void SeedData()
{
    using (var scope = app.Services.CreateAsyncScope())
    {
        var InitializeDB = scope.ServiceProvider.GetRequiredService<IRoleInit>();
        InitializeDB.RoleInit();
    }
}