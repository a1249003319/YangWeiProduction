using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Unity;
using YangWei.Db.Db;
using YangWei.Db.Entity;
using YangWei.Db.IApply;
using YangWei.Db.Uitls;

namespace YangWei.Db.Apply
{
    public class Context : IContext
    {
        public T[] Delete<T>(params T[] model) where T : Entity1
        {
            foreach(var item in model)
            {
                mesDb.Entry(item).State = EntityState.Deleted;
            }
            Commit();
            return model;

        }

        readonly IUserBusiness userBusiness;
        readonly MesDbContext mesDb;
        public Context()
        {
            MesDbContext mesDbContext = new MesDbContext();
            this.mesDb = mesDbContext;
            IUserBusiness userBusiness = IocContainer.Container.Resolve<IUserBusiness>();
            this.userBusiness = userBusiness;
            
        }

        public void Dispose()
        {
           
        }

        public T[] Insert<T>(params T[] model) where T : Entity1
        {
            string userName= userBusiness.Users.UserName;
            foreach(T item in model)
            {
                item.UpdateTime = item.CreateTime = DateTime.Now;
                if (string.IsNullOrWhiteSpace(item.CreateUser)) item.CreateUser = userName;
                item.UpdateUser = item.CreateUser;
                mesDb.Set<T>().Add(item);
            }
            Commit();
            return model;
        }


        public bool Commit()
        {
            var changeCount = mesDb.SaveChanges() > 0;
            while (true)
            {
                var entity = mesDb.ChangeTracker.Entries().FirstOrDefault();
                if (entity == null) break;
                entity.State = EntityState.Detached;
            }
            return changeCount;
        }

        public IQueryable<T> Query<T>() where T : Entity1
        {
            return mesDb.Set<T>().AsNoTracking();
        }

        public int SqlCommand(string sql, params object[] param)
        {
            return mesDb.Database.ExecuteSqlCommand(sql, param);
        }

        public T[] SqlQuery<T>(params T[] model) where T : Entity1
        {
            return mesDb.Set<T>().AsNoTracking().ToArray();
        }

        public DataTable SqlQuery(string sql)
        {
            return null;
        }

        public T[] Update<T>(params T[] model) where T : Entity1
        {
            foreach(var item in model)
            {
                mesDb.Entry(item).State = EntityState.Modified;
                mesDb.Entry(item).Property(item => item.CreateTime).IsModified = false;
                mesDb.Entry(item).Property(item=>item.CreateTime).IsModified = false;
            }
            Commit();
            return model;
        }
    }
}
