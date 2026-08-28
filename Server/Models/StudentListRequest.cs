using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Models
{
    public class StudentListRequest
    {
        public string Keyword { get; set; }
        public string SortBy { get; set; }
        public bool Descending { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
