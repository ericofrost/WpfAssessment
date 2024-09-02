using DataAccess.Repositories;
using Interfaces.Repositories;
using Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Tracking;

namespace Core.Extensions
{
    /// <summary>
    /// Class responsible for configuring the dependency injection of the application
    /// </summary>
    public static class ConfigureDependencyInjection
    {
        /// <summary>
        /// Registers services to the DI Container
        /// </summary>
        /// <param name="services"></param>
        public static void SetUpServices(this IServiceCollection services)
        {
            services.AddSingleton<ISensorsRepository, SensorsRepository>();
            services.AddSingleton<ITrackingService, TrackingService>();
        }

        /// <summary>
        /// Setting up configuration files to be used in the application
        /// </summary>
        /// <param name="services"></param>
        public static void SetUpConfiguration(this IServiceCollection services)
        {
            //var builder = new ConfigurationBuilder()
            //    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //    .AddEnvironmentVariables();

            //services.AddSingleton<IConfiguration>(builder.Build());
        }
    }
}
