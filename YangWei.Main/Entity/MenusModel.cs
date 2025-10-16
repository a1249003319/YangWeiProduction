using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using YangWei.Db.Entity;
using YangWei.Main.Views;

namespace YangWei.Main.Entity
{
    public  class MenusModel
    {
        public int Id { get; set; }
        public byte[] Icon { get; set; }
        public string TitleName { get; set; }
        public IsShows? IsShow { get; set; }
        public Type? ViewType { get; set; }
        public Type? viewType
        {
            get
            {
                if(TitleName == "菜单管理")
                {
                    ViewType = typeof(TestUserControls);                   
                }
                return ViewType;
            }
            set
            {
                ViewType = value;
            }
        }
        public string ReMark { get; set; }

        public BitmapImage Image
        {
            get
            {
                if (Icon == null || Icon.Length == 0)
                    return null;

                var image = new BitmapImage();
                using (var mem = new MemoryStream(Icon))
                {
                    mem.Position = 0;
                    image.BeginInit();
                    image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.UriSource = null;
                    image.StreamSource = mem;
                    image.EndInit();
                }
                image.Freeze();
                return image;
            }
        }
    }
}
