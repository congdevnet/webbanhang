using System;

namespace WebChuyenDe.Data.ViewModel
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string MetaTitle { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public string MoreImages { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> PromotionPrice { get; set; }
        public Nullable<bool> IncludeVAT { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string Detail { get; set; }
        public Nullable<int> Warranty { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescriptions { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> TopHot { get; set; }
        public Nullable<int> ViewCounts { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
}