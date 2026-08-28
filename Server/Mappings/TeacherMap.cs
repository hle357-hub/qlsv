using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Mappings
{
    internal class TeacherMap : ClassMap<Teacher>
    {
        public TeacherMap()
        {
            Table("Teacher");
            Not.LazyLoad();
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.DateBirthDay);
        }
    }
}
