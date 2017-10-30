using FactoryMehtodLib.Model;
using FactoryMehtodLib.SiteBasicInfo.Wrap;
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
        internal bool disposed = false;
        protected internal Joiner TemplateJoiner { get; set; }
        protected internal Joiner CreatedJoiner { get; set; }

        public SiteBasicInfoMaker(Joiner createdJoiner)
        {
            CreatedJoiner = createdJoiner;
        }
        public void Do()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            Dispose(true);
            SuppressFinalize(this);
        }
        protected internal virtual void SuppressFinalize(object obj)
        {
            GC.SuppressFinalize(obj);
        }
        protected internal virtual void Dispose(bool disposing)
        {
            if (disposed) return;
            if (disposing)
            {
                foreach (var prop in GetAllProperties())
                {
                    if (prop.CanWrite) prop.SetValue(this,null);
                }
            }
            disposed = true;
        }
        protected internal virtual PropertyInfo[] GetAllProperties()
        {
            return this.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        }
    }
}