using System;

namespace WebChuyenDe.Data.ViewModel
{
    public class FeedbackViewModel
    {
        public int FeedbackID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Content { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    }
}