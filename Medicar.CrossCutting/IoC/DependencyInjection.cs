using Medicar.Infrastructure.Contex;
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


        return services;
    }
}
