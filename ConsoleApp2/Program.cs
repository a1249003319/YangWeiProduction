using Unity;
using YangWei.Db.Db;
using YangWei.Db.Entity;
using YangWei.Db.IApply;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var userBusiness= IocContainer.Container.Resolve<IUserBusiness>();
            userBusiness.InsUser();
        }
    }
}
