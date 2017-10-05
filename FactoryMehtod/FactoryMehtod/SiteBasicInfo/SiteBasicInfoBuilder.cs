using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMehtodLib.SiteBasicInfo
{
    public interface ISiteBasicInfoBuilder 
    {
        void Builder();
    }
    public class SiteBasicInfoBuilder : ISiteBasicInfoBuilder
    {
        public void Builder()
        {
            throw new NotImplementedException();
        }
    }
}
