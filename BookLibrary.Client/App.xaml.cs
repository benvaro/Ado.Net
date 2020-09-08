using Autofac;
using AutoMapper;
using BookLibrary.BLL.Services;
using BookLibrary.BLL.Utils;
using BookLibrary.DAL;
using BookLibrary.DAL.Repository;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Windows;

namespace BookLibrary.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationContext>().As<DbContext>().SingleInstance();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IGenericRepository<>));
            builder.RegisterType<BookService>().As<IBookService>();
            builder.RegisterType<MainWindow>().AsSelf();

            var config = new MapperConfiguration(cgf => cgf.AddProfile(new MapperConfig()));
            builder.RegisterInstance(config.CreateMapper());

            using (var scope = builder.Build().BeginLifetimeScope())
            {
                var window = scope.Resolve<MainWindow>();
                window.ShowDialog();
            }
        }



    }
}

// new MainWindow(#3)
