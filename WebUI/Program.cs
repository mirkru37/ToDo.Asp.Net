using Application.Common.Interfaces;
using AspNetCore.RouteAnalyzer;
using Domain;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContextConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql("Server=todolistuniversity-server.postgres.database.azure.com;Database=todolistuniversity-database;Port=5432;Ssl Mode=Require;User Id=hquayhruww;Password=AG0UB8R2U782YTU2$;"));

builder.Services.AddDefaultIdentity<UserEntity>(options =>
    {
        options.SignIn.RequireConfirmedEmail = false;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddScoped<IRepository<UserEntity>, UserRepository>();
builder.Services.AddScoped<IRepository<TaskEntity>, TaskRepository>();
builder.Services.AddScoped<IApplicationDBContext, ApplicationDbContext>();
builder.Services.AddRouteAnalyzer();

builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    //options.Cookie.Expiration 
 
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
    // options.LoginPath = "/Login";
    // options.LogoutPath = "/Logout";
    // options.AccessDeniedPath = "/AccessDenied";
    options.SlidingExpiration = true;
    //options.ReturnUrlParameter=""
});
builder.Services.AddRazorPages();

DependencyInjection.ConfigureServices(builder.Services);
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
app.UseAuthentication();;
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});

    app.MapGet("/debug/routes", (IEnumerable<EndpointDataSource> endpointSources) =>
        string.Join("\n", endpointSources.SelectMany(source => source.Endpoints)));


app.Run();
