using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mappings
{
    internal class StudentClassMap : ClassMap<StudentClass>
    {
        public StudentClassMap()
        {
            Table("StudentClass");
            Not.LazyLoad();
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Subject);
            References(x => x.Teacher).Column("Teacher_id");
        }
    }
}
