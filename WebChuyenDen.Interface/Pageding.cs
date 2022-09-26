using System.Collections.Generic;

namespace WebChuyenDen.Interface
{
    public class Pageding<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public List<T> Items { get; set; } = new List<T>();
    }
}