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
        protected internal Joiner TemplateJoiner { get; set; }
        protected internal Joiner CreatedJoiner { get; set; }

        public SiteBasicInfoMaker(Joiner createdJoiner)
        {
            CreatedJoiner = createdJoiner;
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