using System.Configuration;

namespace WebChuyenDe.Service
{
    public class PagesSetup
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
            //=int.Parse(ConfigurationManager.AppSettings["PageSize"]);
       
    }
}