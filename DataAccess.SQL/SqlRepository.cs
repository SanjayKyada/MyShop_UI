using Core;
using DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SQL
{
    public class SqlRepository<T> : IRepositoryBase<T> where T : AbsBase
    {
        internal DataContext dataContext;
        internal DbSet<T> entity;

        public SqlRepository(DataContext dataContextObj)
        {
            dataContext = dataContextObj;
            entity = dataContextObj.Set<T>();
        }

        public void Add(T d)
        {
            entity.Add(d);
        }

        public void Commit()
        {
            dataContext.SaveChanges();
        }

        public void DeleteObject(string ID)
        {
            T existingObj = entity.Find(ID);
            if (dataContext.Entry(existingObj).State == EntityState.Detached)
                entity.Attach(existingObj);
            entity.Remove(existingObj);
        }

        public IQueryable<T> GetAllData()
        {
            return entity;
        }

        public T GetDetail(string ID)
        {
            return entity.Find(ID);
        }

        public void Update(T d)
        {
            entity.Attach(d);
            dataContext.Entry(d).State = EntityState.Modified;

        }
    }
}
