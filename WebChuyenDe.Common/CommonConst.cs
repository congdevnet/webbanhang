using System.Collections.Generic;
using WebChuyenDe.Data.ViewModel;

namespace WebChuyenDe.Common
{
    public static class CommonConst
    {
        public const string SessionUser = "SessionUser";

        public static List<WevSettingUrl> WevSettingUrls
        {
            get
            {
                List<WevSettingUrl> wevSettingUrls = new List<WevSettingUrl>()
                {
                    ///Admin/MenuType/Index
                    new WevSettingUrl(){Id=1, Icon=@"icon", Class=null, Link=null, Name="Bảng điều khiển" },
                    new WevSettingUrl(){Id=2, Icon=@"icon icon-single-04", Class=null, Link="/", Name="Danh sách" },
                    //new WevSettingUrl(){Id=3, Icon=@"icon icon-app-store", Class=null, Link=@"/Admin/Menu/Index", Name="Menu" },
                    new WevSettingUrl(){Id=1, Icon=@"icon icon-chart-bar-33", Class=null, Link=@"/Admin/MenuType/Index", Name="Loại Menu" },
                    new WevSettingUrl(){Id=5, Icon=@"icon icon-world-2", Class=null, Link=@"/Admin/NewCategory/Index", Name="Loại tin tức" },
                    new WevSettingUrl(){Id=6, Icon=@"icon icon-plug", Class=null, Link=@"/Admin/New/Index", Name="Tin tức" },
                    new WevSettingUrl(){Id=7, Icon=@"icon icon-globe-2", Class=null, Link=@"/Admin/ProductCategory/Index", Name="Loại sản phẩm" },
                    new WevSettingUrl(){Id=8, Icon=@"icon icon-form", Class=null, Link=@"/Admin/Product/Index", Name="Sản phẩm" },
                    new WevSettingUrl(){Id=9, Icon=@"icon icon-layout-25", Class=null, Link=@"/Admin/Slider/Index", Name="Trình chuyến" },
                    new WevSettingUrl(){Id=10, Icon=@"icon icon-single-copy-06", Class=null, Link=@"/Admin/Tag/Index", Name="Tag" },
                    new WevSettingUrl(){Id=11, Icon=@"icon icon-single-copy-08", Class=null, Link=@"/Admin/User/Index", Name="Người dùng" },
                };
                return wevSettingUrls;
            }
        }
    }
}