using Microsoft.EntityFrameworkCore;
using Models.MomentoApp;
using Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Concreter
{
    public class ZismedBaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ZismedAppContext _zismedContext = null;
        public DbSet<T> table = null;

        public ZismedBaseRepository(ZismedAppContext zismedContext)
        {
            _zismedContext = zismedContext;
            table = _zismedContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _zismedContext.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public void Save()
        {
            _zismedContext.SaveChanges();
        }
    }
}
