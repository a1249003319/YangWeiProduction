using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Mapster;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using YangWei.Db.Db;
using YangWei.Db.Entity;

namespace YangWei.Main.ViewModel
{
    public partial class AddMenusViewModel:ObservableObject
    {
        [ObservableProperty]
        private BitmapImage? uploadedImage;

        [ObservableProperty]
        public List<string> menusName = new();


        [ObservableProperty]
        public string menus;

        [ObservableProperty]
        public string reMark;


        public AddMenusViewModel()
        {
            MesDbContext mesDbContext = new MesDbContext();
            List<string> menusTitle= mesDbContext.Menus.Where(item => item.ParentId == null).Select(item => item.TitleName).ToList();
            foreach(var data in menusTitle)
            {
                MenusName.Add(data);
            }
        }

        [RelayCommand]
        private void UpLoad()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 创建一个BitmapImage并设置其源
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(openFileDialog.FileName);
                image.EndInit();

                // 将图片赋值给UploadedImage属性
                UploadedImage = image;
            }
        }
        public static Action CloseAction;

        [RelayCommand]
        public void AddMenus()
        {
            if (string.IsNullOrWhiteSpace(Menus))
            {
                UIMessageTip.ShowError("菜单名称不能为空");
                return;
            }

            if (string.IsNullOrWhiteSpace(ReMark))
            {
                UIMessageTip.ShowError("描述不能为空");
                return;
            }

            if (UploadedImage == null)
            {
                UIMessageTip.ShowError("图片不能为空");
                return;
            }

            MesDbContext mesDbContext = new MesDbContext();
            int count= mesDbContext.Menus.Where(item => item.TitleName == Menus).Count();
            if(count > 0)
            {
                UIMessageTip.ShowError("不能重复添加");
                return;
            }
            Menus menus=new Menus();
            menus.TitleName = Menus;
            menus.Icon = BitmapImageToByteArray(UploadedImage);
            menus.ReMark = ReMark;
            menus.IsShow = IsShows.Show;
            mesDbContext.Menus.Add(menus);
            mesDbContext.SaveChanges();
            UIMessageTip.ShowOk("添加成功");
            CloseAction?.Invoke();


        }
        public byte[] BitmapImageToByteArray(BitmapImage bitmapImage)
        {
            byte[] data;

            // 方法一：通过编码器转换
            BitmapEncoder encoder = new PngBitmapEncoder(); // 也可以使用 JpegBitmapEncoder, BmpBitmapEncoder 等
            encoder.Frames.Add(BitmapFrame.Create(bitmapImage));

            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }

            return data;
        }

        public byte[] BitmapImageToByteArrayAlternative(BitmapImage bitmapImage)
        {
            if (bitmapImage.StreamSource != null && bitmapImage.StreamSource.CanRead)
            {
                using(MemoryStream ms=new MemoryStream())
                {
                    bitmapImage.StreamSource.CopyTo(ms);
                    return ms.ToArray();
                }
            }
            return BitmapImageToByteArray(bitmapImage);
        }
    }
}
