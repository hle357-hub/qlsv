using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Entities
{
    public class StudentClass
    {
        public virtual string Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
