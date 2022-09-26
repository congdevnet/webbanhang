using System;

namespace WebChuyenDe.Data.ViewModel
{
    public class OrderDetailVm
    {
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<decimal> Price { get; set; }
    }
}