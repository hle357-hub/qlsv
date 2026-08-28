using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mappings
{
    internal class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Table("Student");
            Not.LazyLoad();
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.DateBirthDay);
            Map(x => x.Address);
            References(x => x.StudentClass).Column("StudentClass_id");
            Map(x => x.GpaEnglish);
            Map(x => x.GpaLiterature);
            Map(x => x.GpaMath);
        }
    }
}
