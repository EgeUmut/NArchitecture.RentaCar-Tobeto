﻿using Application.Services.Repositories;
using DataAccess.Concretes.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("Tobeto3ANArch")));

        services.AddScoped<IBrandRepository, BrandRepository>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();

        return services;
    }
}
