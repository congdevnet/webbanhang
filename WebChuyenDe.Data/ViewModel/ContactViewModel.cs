using System;

namespace WebChuyenDe.Data.ViewModel
{
    public class ContactViewModel
    {
        public int ContactID { get; set; }
        public string Content { get; set; }
        public Nullable<bool> Status { get; set; }
    }
}