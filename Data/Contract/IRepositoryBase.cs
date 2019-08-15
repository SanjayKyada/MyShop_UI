using System.Linq;
using Core;

namespace DataAccess.InMemory
{
    public interface IRepositoryBase<DC> where DC : AbsBase
    {
        void Add(DC d);
        void Commit();
        void DeleteObject(string ID);
        IQueryable<DC> GetAllData();
        DC GetDetail(string ID);
        void Update(DC d);
    }
}