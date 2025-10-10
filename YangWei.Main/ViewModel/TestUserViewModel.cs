using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mapster;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YangWei.Db.Db;
using YangWei.Db.Entity;
using YangWei.Main.Entity;
using YangWei.Main.Views;

namespace YangWei.Main.ViewModel
{
    public partial class TestUserViewModel:ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<MenusModel> menusModelList = new();


        [ObservableProperty]
        public MenusModel menusModel = new();
        public TestUserViewModel()
        {
            List<MenusModel> menusModel=new List<MenusModel>();
            MesDbContext mesDbContext=new MesDbContext();
            var menusList= mesDbContext.Menus.ToList();
            List<MenusModel> menusModels = menusList.Adapt<List<MenusModel>>().Adapt(new List<MenusModel>());
            foreach (var data in menusModels) MenusModelList.Add(data);
        }


        [RelayCommand]
        public void SelectedChanged()
        {

        }

        [RelayCommand]
        public void Edit()
        {

        }


        [RelayCommand]
        public void AddMenus()
        {
            AddMenusPage addMenusPage=new AddMenusPage();
            addMenusPage.ShowDialog();

            //TestUserViewModel();

        }
    }
}
