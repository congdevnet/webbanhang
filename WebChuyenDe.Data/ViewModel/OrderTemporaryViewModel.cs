using System;

namespace WebChuyenDe.Data.ViewModel
{
    public class OrderTemporaryViewModel
    {
        public int ProductId { get; set; }
        public Nullable<decimal> UnitPrice { get; set; }
        public Nullable<int> Amount { get; set; }
        public string Img { get; set; }
        public string Sesion { get; set; }
    }
}