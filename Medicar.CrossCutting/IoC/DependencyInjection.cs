﻿using Medicar.Application.Interfaces;
using Medicar.Application.Mappings;
using Medicar.Application.Services;
using Medicar.Domain.Interfaces;
using Medicar.Infrastructure.Contexs;
using Medicar.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Medicar.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        #region EF Config

        services.AddDbContext<ApplicationDbContext>(opts => opts.UseNpgsql(configuration["ConnectionStrings:DbConnection"]));

        #endregion

        #region AutoMapper

        services.AddAutoMapper(typeof(AutoMapping));

        #endregion

        #region Services

        services.AddScoped<IRepositoryUoW, RepositoryUoW>();
        services.AddScoped<ISpecialtyService, SpecialtyService>();

        #endregion

        return services;
    }
}
