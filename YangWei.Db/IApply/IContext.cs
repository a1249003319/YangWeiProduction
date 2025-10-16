using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangWei.Db.Uitls;

namespace YangWei.Db.IApply
{
    public interface IContext :IDisposable
    {
        IQueryable<T> Query<T>() where T : Entity1;


        T[] Insert<T>(params T[] model) where T : Entity1;
        T[] Update<T>(params T[] model)where T : Entity1;        
        T[] Delete<T>(params T[] model) where T : Entity1;

        T[] SqlQuery<T>(params T[] model) where T: Entity1;


        int SqlCommand(string sql,params object[] param);

        DataTable SqlQuery(string sql);

    }
}
