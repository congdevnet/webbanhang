using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChuyenDe.Data.ViewModel
{
    public class NewViewModel
    {
        public int NewID { get; set; }
        public string Title { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string NewImage { get; set; }
        public Nullable<int> NewCategoryID { get; set; }
        public string Detail { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> TopHot { get; set; }
        public Nullable<int> ViewCount { get; set; }
        public string TagID { get; set; }

        public virtual NewCategoryViewModel NewCategory { get; set; }

        //public virtual IEnumerable<TagViewModel> Tags { get; set; }
    }
}
