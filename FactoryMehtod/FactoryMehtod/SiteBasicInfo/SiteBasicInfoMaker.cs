using FactoryMehtodLib.Model;
using System;

namespace FactoryMehtodLib.SiteBasicInfo
{
    public interface ISiteBasicInfoMaker : IDisposable
    {
        void Do();
    }
    public class SiteBasicInfoMaker : ISiteBasicInfoMaker
    {
        protected Joiner TemplateJoiner { get; set; }
        protected Joiner CreatedJoiner { get; set; }

        public SiteBasicInfoMaker()
        {

        }
        public void Do()
        {

        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}