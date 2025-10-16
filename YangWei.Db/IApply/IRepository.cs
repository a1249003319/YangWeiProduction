using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YangWei.Db.IApply
{
    public interface IRepository<T> where T :new()
    {
        IQueryable<T> Query();
        bool Insert(params T[] entity);
        bool Update(params T[] entity);
        bool Delete(params T[] entity);

    }
}
