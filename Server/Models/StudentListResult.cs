using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Models
{
    public class StudentListResult
    {
        public List<Student> Students { get; set; } = new();
        public int Total { get; set; }
    }
}
