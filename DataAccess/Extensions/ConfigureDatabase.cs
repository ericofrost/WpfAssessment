using DataAccess.Contexts;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Extensions
{
    public static class ConfigureDatabase
    {
        /// <summary>
        /// Configures the Data Base Context
        /// </summary>
        /// <param name="service"></param>
        /// <param name="connectionString"></param>
        public static void ConfigureDataContexts(this IServiceCollection service)
        {
            service.AddDbContext<ApplicationDbContext>(ServiceLifetime.Singleton);

            //service.AddSingleton<IAppSettingsRepository, AppSettingsRepository>();
        }
    }
}
