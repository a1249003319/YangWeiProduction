using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using YangWei.Db.Apply;
using YangWei.Db.IApply;

namespace YangWei.Db.Db
{
    public class IocContainer
    {
        public static IUnityContainer Container;
        //public static IUnityContainer Containers()
        //{

        //    IUnityContainer container = new UnityContainer();
        //    container.RegisterType<IUserBusiness, UserBusiness>();
        //    container.RegisterType<IMemoryProfileService, MemoryProfileService>();
        //    container.RegisterType<IServiceProvider>();
        //    return container;
        //}


       static IocContainer()
        {
            Container = new UnityContainer();
            Container.RegisterType<IUserBusiness, UserBusiness>();
            Container.RegisterType<IMemoryProfileService, MemoryProfileService>();
            Container.RegisterType<IServiceProvider>();
        }

    }
}
