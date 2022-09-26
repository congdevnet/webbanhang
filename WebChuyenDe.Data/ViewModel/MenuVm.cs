using System;

namespace WebChuyenDe.Data.ViewModel
{
    public class MenuVm
    {
        public int MenuID { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string Target { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<int> MenuTypeID { get; set; }
        public Nullable<int> MenuParentID { get; set; }
    }
}