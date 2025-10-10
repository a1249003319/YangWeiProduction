using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YangWei.Main.Views
{
    public class MenuItem:ObservableObject
    {
        public string Title { get; set; }
        public string Icon { get; set; } // 可以使用Material Design图标或字体图标
        public Type ViewType { get; set; }
        public bool IsSelected { get; set; }
    }
}
