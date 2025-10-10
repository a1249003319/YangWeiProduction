using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using YangWei.Main.ViewModel;

namespace YangWei.Main.Views
{
    /// <summary>
    /// MainPages.xaml 的交互逻辑
    /// </summary>
    public partial class MainPages : Window
    {
        readonly LoginView loginView;
        public static Action CloseView;
        public MainPages(LoginView loginView)
        {
            InitializeComponent();
            this.loginView=loginView;
            this.DataContext = new MainPagesViewModel();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            // CloseView?.Invoke();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 这里可以处理关闭前的逻辑
            MessageBoxResult result = MessageBox.Show("确定要关闭窗口吗？", "确认",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; // 取消关闭操作
            }
            else
            {
               
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            // 处理关闭逻辑
            MessageBoxResult result = MessageBox.Show("确定要退出程序吗？", "确认",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true; // 阻止窗口关闭
            }
            else
            {
                // 执行清理操作
                Application.Current.Shutdown();
            }
        }
    }
}
