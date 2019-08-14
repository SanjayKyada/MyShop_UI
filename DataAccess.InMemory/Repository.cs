using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace DataAccess.InMemory
{
    public class Repository<DC> : IRepositoryBase<DC> where DC : AbsBase
    {
        ObjectCache dyCacheObj = MemoryCache.Default;
        List<DC> dynamicClassObj;
        string name;

        public Repository()
        {
            name = typeof(DC).Name;
            dynamicClassObj = dyCacheObj[name] as List<DC>;
            if (dynamicClassObj == null)
                dynamicClassObj = new List<DC>();
        }
        //cache updating..
        public void Commit()
        {
            dyCacheObj[name] = dynamicClassObj;
        }
        // Collection...=>List of objects
        public IQueryable<DC> GetAllData()
        {
            return dynamicClassObj.AsQueryable();
        }

        //Insert a new record.
        public void Add(DC d)
        {
            dynamicClassObj.Add(d);
        }

        //get details of specific record.
        public DC GetDetail(string ID)
        {
            DC dcObj = dynamicClassObj.Find(x => x.Id == ID);
            if (dcObj == null)
                throw new Exception("There is no such record in " + name + " List.");
            else
                return dcObj;
        }

        //Update details of existing object's details.
        public void DeleteObject(string ID)
        {
            DC dcObj = GetDetail(ID);
            dynamicClassObj.Remove(dcObj);
        }

    }

}
