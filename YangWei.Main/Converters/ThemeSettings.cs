using MaterialDesignThemes.Wpf;
using Syncfusion.SfSkinManager;
using Syncfusion.Themes.Windows11Light.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace YangWei.Main.Converters
{
    public class ThemeSettings
    {
        public static readonly Lazy<ThemeSettings> _instance=new Lazy<ThemeSettings>(() => new ThemeSettings());

        public static ThemeSettings Instace => _instance.Value;

        private readonly IThemeSetting _theme;
        private readonly string _themeName = "Windows11Light";
        private ThemeSettings()
        {
            _theme = GetWindows11LightThemeSettings();
            SfSkinManager.RegisterThemeSettings(_themeName, _theme);
        }
        public static void InitWindows11LightStyle()
        {
            var themes=GetWindows11LightThemeSettings();
            SfSkinManager.RegisterThemeSettings("Windows11Light", themes);
        }


        public void SetTheme(System.Windows.DependencyObject dependencyObject,params string[] controls)
        {
            return;
            SfSkinManager.SetTheme(dependencyObject, new Syncfusion.SfSkinManager.Theme(_themeName));
        }

        public static IThemeSetting GetWindows11LightThemeSettings()
        {
            var themeSettings = new Windows11LightThemeSettings
            {
                Palette = Windows11Palette.Default,
                PrimaryBackground = new SolidColorBrush(new Color { A = 255, R = 80, G = 160, B = 255 }),
                PrimaryForeground=new SolidColorBrush(Colors.White),
                HeaderFontSize=12,
                SubHeaderFontSize=12,
                TitleFontSize=12,
                SubTitleFontSize=12,
                BodyFontSize=12,
                BodyAltFontSize=12,
                FontFamily=new FontFamily("Microsoft Yahei UI")

            };
            return themeSettings;
        }
    }
}
