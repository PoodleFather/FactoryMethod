using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMehtodLib.SiteBasicInfo.Wrap
{
    public interface IActivatorWrap
    {
        object CreateInstance(Type type);
    }
    public class ActivatorWrap : IActivatorWrap
    {
        public object CreateInstance(Type type)
        {
            return Activator.CreateInstance(type);
        }
        
    }
}
