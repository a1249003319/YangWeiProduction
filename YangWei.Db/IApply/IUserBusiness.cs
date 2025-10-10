using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangWei.Db.Entity;

namespace YangWei.Db.IApply
{
    public interface IUserBusiness
    {
        public void InsUser();
        public Users Users { get;set; }

        public Users Login(string userName,string password);
    }
}
