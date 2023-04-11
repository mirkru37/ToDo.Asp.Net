using Application.Common.Interfaces;
using Domain;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped<IRepository<UserEntity>, UserRepository>();
    }
}