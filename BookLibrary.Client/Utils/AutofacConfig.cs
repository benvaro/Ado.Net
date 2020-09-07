using Autofac;
using BookLibrary.DAL;
using BookLibrary.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Client.Utils
{
    public class AutofacConfig
    {
        public AutofacConfig()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationContext>().As<DbContext>();
            builder.RegisterGeneric(typeof(EFRepository<>)).As(typeof(IGenericRepository<>));

            builder.Build();
        }
    }
}
