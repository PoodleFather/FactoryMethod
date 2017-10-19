using FactoryMehtodLib.Model;
using System;
using System.Reflection;

namespace FactoryMehtodLib.SiteBasicInfo
{
    public interface ISiteBasicInfoMaker : IDisposable
    {
        void Do();
    }
    public class SiteBasicInfoMaker : ISiteBasicInfoMaker
    {
        private bool disposed = false;
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
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if (disposing)
            {
                foreach (var prop in this.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance))
                {
                    if (prop.CanWrite) prop.SetValue(this,null);
                }
            }
            
            disposed = true;
        }
    }
}