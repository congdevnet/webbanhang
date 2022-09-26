using System;
using System.Collections.Generic;

namespace WebChuyenDe.Data.ViewModel
{
    public class NewCategoryViewModel
    {
        public int NewCategoryID { get; set; }
        public string Name { get; set; }
        public string MetaTitle { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> DisplayOrder { get; set; }
        public string SeoTitle { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<bool> ShowOnHome { get; set; }
    }
}