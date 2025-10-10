using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using Unity;
using YangWei.Db.Apply;
using YangWei.Db.Db;
using YangWei.Db.Entity;
using YangWei.Db.IApply;
using YangWei.Main.Views;

namespace YangWei.Main.ViewModel
{
    public partial class LoginViewModel:ObservableObject
    {
        readonly IUserBusiness userBusiness;
        readonly LoginView loginView;
        public LoginViewModel(LoginView loginView)
        {
            IUserBusiness userBusiness = IocContainer.Container.Resolve<IUserBusiness>();
            this.userBusiness=userBusiness;
            userBusiness.InsUser();
            this.loginView= loginView;
        }

        [ObservableProperty]
        public string userName;

        [ObservableProperty]
        public string password;





        [RelayCommand]
        public void Login()
        {
           
           Users users= userBusiness.Login(UserName,Password);
            if (users == null)
            {
                UIMessageTip.ShowError("账号或密码输入错误");
                return;
            }
            MesDbContext mesDbContext = new MesDbContext();
            Users userUtils= mesDbContext.Users.Find(users.Id);
            userUtils.State = IsState.OnState;
            UIMessageTip.ShowOk("登录成功");
            var mamoryProfileService= IocContainer.Container.Resolve<IMemoryProfileService>();
            mamoryProfileService.Set<Users>("User", userUtils);
            loginView.Hide();
            MainPages mainPages = new MainPages(loginView);
            mainPages.Show();
            //TestWindow testWindow=new TestWindow();
            //testWindow.Show();
        }
    }
}
