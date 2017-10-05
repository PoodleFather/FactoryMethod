using Autofac;
using FactoryMehtodLib.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FactoryMehtodLib.Repository
{
    public interface IRepository<T>
    {
        void Insert(T item);
        void Delete(T item);
        void Update(T item);
        void Save();
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        public Entities Entity;

        public Repository()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Entities>().As<Entities>();
            var container = builder.Build();
            Entity = container.Resolve<Entities>();
        }
        public T GetById(int id)
        {
            return Entity.Set<T>().Find(id);
        }
        public void Insert(T item)
        {
            Entity.Set<T>().Add(item);
        }
        public void Delete(T item)
        {
            Entity.Set<T>().Remove(item);
        }
        public void Update(T item)
        {
            Entity.Entry(item).State = EntityState.Modified;
        }
        public void Save()
        {
            Entity.SaveChanges();
        }
        public IEnumerable<T> GetAll()
        {
            return Entity.Set<T>();
        }
    }
}
