using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mapster;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Unity;
using YangWei.Db.Db;
using YangWei.Db.Entity;
using YangWei.Db.IApply;
using YangWei.Main.Entity;
using YangWei.Main.Views;

namespace YangWei.Main.ViewModel
{
    public partial class MainPagesViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserControl _currentView;

        [ObservableProperty]
        private MenusModel? _selectedMenuItem;

        [ObservableProperty]
        public ObservableCollection<MenusModel> menuItems = new();

        public MainPagesViewModel()
        {

            MesDbContext mesDbContext = new MesDbContext();
            List<Menus> menus = mesDbContext.Menus.Where(item => item.IsShow == IsShows.Show).ToList();
            List<MenusModel> menusModelList= menus.Adapt<List<MenusModel>>().Adapt(new List<MenusModel>());
            // 初始化菜单项
            //MenuItems = new ObservableCollection<Views.MenuItem>
            //{
            //    new Views.MenuItem { Title = "仪表板", Icon = "", ViewType = typeof(TestUserControls) }
            //    //new Views.MenuItem { Title = "用户管理", Icon = "", ViewType = typeof(UserManagementView) },
            //    //new Views.MenuItem { Title = "设置", Icon = "", ViewType = typeof(SettingsView) },
            //    //new Views.MenuItem { Title = "帮助", Icon = "󰋖", ViewType = typeof(HelpView) }
            //};
            // 设置默认视图
            foreach(var data in menusModelList)
            {
                MenuItems.Add(data);
            }
            //SelectedMenuItem = MenuItems.FirstOrDefault();
           // CurrentView = (UserControl)Activator.CreateInstance(SelectedMenuItem.ViewType);
        }
        [RelayCommand]
        private void MenuSelectionChanged()
        {
            if (SelectedMenuItem != null)
            {
                CurrentView = (UserControl)Activator.CreateInstance(SelectedMenuItem.ViewType);
            }
        }
        //partial void OnSelectedMenuItemChanged(Views.MenuItem? value)
        //{
        //    MenuSelectionChanged();
        //}
    }
}
