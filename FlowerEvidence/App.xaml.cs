using FlowerEvidence.Database;
using FlowerEvidence.Factory;
using FlowerEvidence.Interfaces;
using FlowerEvidence.Managers;
using FlowerEvidence.Repositories;
using FlowerEvidence.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace FlowerEvidence
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            // zaregistrujeme si Databázi

            services.AddDbContext<FlowerContext>(options =>
            options.UseSqlite("Data Source=FlowerDb.db"),ServiceLifetime.Scoped);

            services.AddScoped<IFlowerRepository, FlowerRepository>();
            services.AddScoped<IFlowerManager, FlowerManager>();
            services.AddScoped<IFlowerFactory, FlowerFactory>();

            services.AddTransient<MainWindow>();
            services.AddTransient<AddNewFlowerWindow>();
            services.AddTransient<UpdateExistingFlowerWindow>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow main= _serviceProvider.GetService<MainWindow>();
            main.Show();
        }
    }

}
