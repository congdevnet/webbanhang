using System.Collections.Generic;

namespace WebChuyenDe.Service
{
    public class Pagesding<T>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalPage { get; set; }
        public List<T> Items { get; set; } = new List<T>();
    }
}