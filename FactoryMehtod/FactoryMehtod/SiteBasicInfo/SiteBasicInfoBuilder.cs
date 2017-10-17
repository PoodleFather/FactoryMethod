using Autofac;
using FactoryMehtodLib.SiteBasicInfo.Wrap;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
[assembly: InternalsVisibleTo("FactoryMethodLib.Test")]

namespace FactoryMehtodLib.SiteBasicInfo
{
    public enum SiteBasicInfoMakerType
    {
        BoardAdmin,
        Categroy
    }

    public interface ISiteBasicInfoBuilder 
    {
        void DoBuild();
    }
    public class SiteBasicInfoBuilder : ISiteBasicInfoBuilder
    {
        public IActivatorWrap ActivatorWrap { get; set; }
        public ITypeWrap TypeWrap { get; set; }

        public SiteBasicInfoBuilder()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ActivatorWrap>().As<IActivatorWrap>();
            builder.RegisterType<TypeWrap>().As<ITypeWrap>();
            var Container = builder.Build();
            ActivatorWrap = Container.Resolve<IActivatorWrap>();
            TypeWrap = Container.Resolve<ITypeWrap>();
        }

        public void DoBuild()
        {
            DoMaker();
        }

        protected internal virtual void DoMaker()
        {
            foreach (SiteBasicInfoMakerType type in Enum.GetValues(typeof(SiteBasicInfoMakerType)))
            {
                using (var maker = GetMaker(type))
                {
                    maker.Do();
                }
            }
        }

        protected internal virtual ISiteBasicInfoMaker GetMaker(SiteBasicInfoMakerType type)
        {
            return GetInstance(type);
        }

        protected internal virtual ISiteBasicInfoMaker GetInstance(SiteBasicInfoMakerType type)
        { 
            return CreateIntance(GetTypeOfNameSpace(type));
        }

        protected internal virtual Type GetTypeOfNameSpace(SiteBasicInfoMakerType type)
        {
            Type makerType = TypeWrap.GetType($"FactoryMehtodLib.SiteBasicInfo.{type.ToString()}Maker");
            if (makerType == null) throw new Exception(type.ToString() + "  is  not valid SiteBasicInfoMakerType ");
            return makerType;
        }

        protected internal virtual ISiteBasicInfoMaker CreateIntance(Type classType)
        {
            return (ISiteBasicInfoMaker)ActivatorWrap.CreateInstance(classType);
        }
    }
}
