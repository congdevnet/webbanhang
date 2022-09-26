using System.Configuration;

namespace WebChuyenDen.Interface
{
    public class PageSetup
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; }  = int.Parse(ConfigurationManager.AppSettings["PageSize"]);
        public PageSetup(int _Page) {
            Page = _Page;
        }
    }
}