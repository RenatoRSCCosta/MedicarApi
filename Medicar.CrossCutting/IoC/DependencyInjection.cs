using Medicar.Application.Mappings;
using Medicar.Infrastructure.Contexs;
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

        return services;
    }
}
