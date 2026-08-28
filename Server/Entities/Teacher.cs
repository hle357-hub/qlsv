using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Entities
{
    public class Teacher
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime DateBirthDay { get; set; }
    }
}
