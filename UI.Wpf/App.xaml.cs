using Core.Extensions;
using DataAccess.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace UI.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            this._serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            // Register your services and view models here
            services.ConfigureDataContexts();
            services.AddSingleton<MainWindow>();
            services.SetUpServices();
            services.SetUpConfiguration();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();

            mainWindow.Show();
        }
    }

}
