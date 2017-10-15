using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMehtodLib.SiteBasicInfo.Wrap
{
    public interface ITypeWrap
    {
        Type GetType(string typeName);
    }
    public class TypeWrap : ITypeWrap
    {
        public Type GetType(string typeName)
        {
            return Type.GetType(typeName);
        }
    }
}
