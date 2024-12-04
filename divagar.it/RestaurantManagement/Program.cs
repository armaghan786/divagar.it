using BulkyBook.DataAccess.DbInitializer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using RestaurantManagement;
using RestaurantManagement.Models;
using Stripe;
using System.Text.Json.Serialization;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RestaurantContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<RestaurantContext>();


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<RestaurantContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });

builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDbInitializer, DbInitializer>();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IEmailSender, EmailSender>();

var app = builder.Build();

var stripeSettings = app.Services.GetRequiredService<IOptions<StripeSettings>>().Value;
StripeConfiguration.ApiKey = stripeSettings.SecretKey;

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
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
SeedDatabase();
app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=FoodMenu}/{id?}");

    // Custom route for food-menu
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "food-menu",
        defaults: new { controller = "Home", action = "FoodMenu" });
    endpoints.MapControllerRoute(
      name: "AsportoMenu",
      pattern: "menu-asporto",
      defaults: new { controller = "Home", action = "AsportoMenu" });
    endpoints.MapControllerRoute(
      name: "BevandeMenu",
      pattern: "menu-bevande",
      defaults: new { controller = "Home", action = "BevandeMenu" });

    endpoints.MapControllerRoute(
        name: "viniMenu",
        pattern: "vini-menu",
        defaults: new { controller = "Home", action = "WineMenu" });

    endpoints.MapControllerRoute(
        name: "Menu",
        pattern: "Webappmenu",
        defaults: new { controller = "Home", action = "Menu" });

     endpoints.MapControllerRoute(
        name: "MenuNevigator",
        pattern: "menu-navigator",
        defaults: new { controller = "Home", action = "MenuNavigator" });

    endpoints.MapControllerRoute(
          name: "identityAccountLogin",
          pattern: "Identity/Account/Login",
          defaults: new { area = "Identity", controller = "Account", action = "Login" });

});
app.Run();


void SeedDatabase()
{
    using (var scope = app.Services.CreateScope())
    {
        var dbInitializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
        dbInitializer.Initialize();
    }
}