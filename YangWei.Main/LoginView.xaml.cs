using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using YangWei.Db.Db;
using YangWei.Db.Entity;
using YangWei.Main.ViewModel;
using YangWei.Main.Views;

namespace YangWei.Main
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Window
    {
        MesDbContext _mesDbContext;
        public LoginView()
        {
            InitializeComponent();

            this.DataContext = new LoginViewModel(this);

            MainPages.CloseView = () =>
            {
                this.Close();
            };
        }
    }
}
