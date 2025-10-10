using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using YangWei.Db.Db;
using YangWei.Db.Entity;
using YangWei.Db.IApply;

namespace YangWei.Db.Apply
{
    public class UserBusiness : IUserBusiness
    {
        public Users Users { get; set; }

        public UserBusiness()
        {
            var mamoryProfileService = IocContainer.Container.Resolve<IMemoryProfileService>();
            var users = mamoryProfileService.Get<Users>("User");
            Users = users;  
        }
        public void InsUser()
        {
            MesDbContext mesDbContext = new MesDbContext();
            int resultCount= mesDbContext.Users.Count();
            if (resultCount == 0)
            {
                Users users = new Users{UserName="admin",Password="123456",NikeName="管理员"};
                mesDbContext.Users.Add(users);
                mesDbContext.SaveChanges();
            }
        }

        public Users Login(string userName,string passWord)
        {
            MesDbContext mesDbContext = new MesDbContext();
            if (userName == null) return null;
            if (passWord == null) return null;
            Users users= mesDbContext.Users.FirstOrDefault(item=>item.UserName == userName&&item.Password==passWord);
            if (users == null) return null;
            return users;
        }
    }
}
