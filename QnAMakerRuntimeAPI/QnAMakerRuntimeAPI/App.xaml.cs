using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QnAMakerRuntimeAPI.Providers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace QnAMakerRuntimeAPI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


            //Configuration //
            var builder = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
              /*Using user secrets in development to keep keys out of source control, 
              to use this sample you will need to populate secret values to match the empty ones in appsettings.json.
              see https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.1&tabs=windows for more info
            */
                                .AddUserSecrets<App>();
          

            IConfigurationRoot root = builder.Build();

            //Seed DI Container
            IServiceCollection myServices = new ServiceCollection();

            myServices.AddSingleton<IConfiguration>(root);
            ConfigureServices(myServices);

            var provider = myServices.BuildServiceProvider();
            Services = provider;
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IQnAGateway, QnAGateway>();

        }
    }
}