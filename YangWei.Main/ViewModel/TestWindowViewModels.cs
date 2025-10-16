using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using YangWei.Db.Db;
using YangWei.Db.Entity;

namespace YangWei.Main.ViewModel
{
    public partial class TestWindowViewModels:ObservableObject
    {
        private MenuItem _selectedMenuItem;


        [ObservableProperty]
        public ObservableCollection<MenuItem> menuItems;

        public MenuItem SelectedMenuItem
        {
            get => _selectedMenuItem;
            set
            {
                _selectedMenuItem = value;
                OnPropertyChanged();
            }
        }

        public TestWindowViewModels()
        {

           




            MenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem
                {
                    Title = "仪表板",
         
                    Children = new ObservableCollection<MenuItem>()
                },
                new MenuItem
                {
                    Title = "用户管理",
         
                    Children = new ObservableCollection<MenuItem>
                    {
                        new MenuItem { Title = "用户列表" },
                        new MenuItem { Title = "角色管理" },
                        new MenuItem { Title = "权限设置" }
                    }
                },
                new MenuItem
                {
                    Title = "内容管理",
                    Children = new ObservableCollection<MenuItem>
                    {
                        new MenuItem { Title = "文章管理",  },
                        new MenuItem { Title = "分类管理" },
                        new MenuItem { Title = "标签管理" }
                    }
                },
                new MenuItem
                {
                    Title = "系统设置",
           
                    Children = new ObservableCollection<MenuItem>
                    {
                        new MenuItem { Title = "基本设置" },
                        new MenuItem { Title = "通知设置" },
                        new MenuItem { Title = "备份恢复" }
                    }
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MenuItem : INotifyPropertyChanged
    {
        private bool _isExpanded;

        public string Title { get; set; }
        public ObservableCollection<MenuItem> Children { get; set; }

        public bool IsExpanded
        {
            get => _isExpanded;
            set
            {
                _isExpanded = value;
                OnPropertyChanged();
            }
        }

        public bool HasChildren => Children?.Count > 0;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
