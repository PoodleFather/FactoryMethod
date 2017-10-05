using Autofac;
using FactoryMehtodLib.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMehtodLib.Repository
{
    public interface IUnitOfWorks
    {
    }
    public class UnitOfWorks : IUnitOfWorks
    {
        public IBoardAdminRepo BoardAdminRepo { get; set; }

        public UnitOfWorks()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<BoardAdminRepo>().As<IBoardAdminRepo>();
            var Container = builder.Build();
            BoardAdminRepo = Container.Resolve<IBoardAdminRepo>();
        }
    }
}
