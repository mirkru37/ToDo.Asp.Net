using Application.Common.Interfaces;
using Domain;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql("Host=localhost;Database=to_do_list;Username=postgres;Password=159357"));
builder.Services.AddScoped<IRepository<UserEntity>, UserRepository>();
builder.Services.AddScoped<IRepository<TagEntity>, TagRepository>();
builder.Services.AddScoped<IRepository<TaskEntity>, TaskRepository>();
builder.Services.AddScoped<IRepository<FolderEntity>, FolderRepository>();
builder.Services.AddScoped<IApplicationDBContext, ApplicationDbContext>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();