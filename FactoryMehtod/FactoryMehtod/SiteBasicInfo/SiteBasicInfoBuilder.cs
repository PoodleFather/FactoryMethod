using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
[assembly: InternalsVisibleTo("FactoryMethodLib.Test")]

namespace FactoryMehtodLib.SiteBasicInfo
{
    public enum SiteBasicInfoMakerType
    {
        BoardAdmin
    }

    public interface ISiteBasicInfoBuilder 
    {
        void Builder();
    }
    public class SiteBasicInfoBuilder : ISiteBasicInfoBuilder
    {
        public void Builder()
        {
            DoMaker();
        }

        protected internal virtual void DoMaker()
        {
            throw new NotImplementedException();
        }

        internal ISiteBasicInfoMaker GetMaker(SiteBasicInfoMakerType type)
        {
            throw new NotImplementedException();
        }
    }
}
