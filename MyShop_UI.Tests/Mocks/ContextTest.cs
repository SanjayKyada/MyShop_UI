using Core;
using Core.Contract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyShop_UI.Tests.Mocks
{
    public class ContextTest<DC> : IRepositoryBase<DC> where DC : AbsBase
    {
        List<DC> dynamicClassObj;

        public ContextTest()
        {
            dynamicClassObj = new List<DC>();
        }
        //cache updating..
        public void Commit()
        {
            return;
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
            return dcObj;
        }

        //Update details of existing object's details.
        public void DeleteObject(string ID)
        {
            DC dcObj = GetDetail(ID);
            dynamicClassObj.Remove(dcObj);
        }

        public void Update(DC d)
        {
            throw new NotImplementedException();
        }
    }

}