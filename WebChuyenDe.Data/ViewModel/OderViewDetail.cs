using System;

namespace WebChuyenDe.Data.ViewModel
{
    public class OderViewDetail
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string ShipName { get; set; }
        public string ShipMobile { get; set; }
        public string ShipAddress { get; set; }
        public string ShipEmail { get; set; }
        public Nullable<bool> Status { get; set; }



    }
}