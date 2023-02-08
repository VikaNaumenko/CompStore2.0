using Bll.Service;
using Dll.Context;
using Dll.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;

namespace CompStoreVersion2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider provider;

        public App()
        {
            ServiceCollection service = new ServiceCollection();
            ConfigureService(service);
            provider = service.BuildServiceProvider();
        }

        private void ConfigureService(ServiceCollection services)
        {
            services.AddDbContext<CompStoreVersion2Context>(option => { option.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = CompStore2; Integrated Security = True;"); });
           
            services.AddTransient<BrandRepository>();
            services.AddTransient<BrandService>();
            services.AddTransient<MainWindow>();
        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var wind = provider.GetService<MainWindow>();
        }
               
    }
}
