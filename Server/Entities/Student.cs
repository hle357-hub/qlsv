using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Entities
{
    public class Student
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime DateBirthDay { get; set; }
        public virtual string Address { get; set; }
        public virtual StudentClass StudentClass { get; set; }
        public virtual double GpaMath { get; set; }
        public virtual double GpaLiterature { get; set; }
        public virtual double GpaEnglish { get; set; }
    }
}
