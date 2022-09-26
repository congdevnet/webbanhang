using System;

namespace WebChuyenDe.Data.ViewModel
{
    public class OrderDetailViewModel
    {
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }

        public  OrderViewModel Order { get; set; }
        public ProductViewModel Product { get; set; }
    }
}