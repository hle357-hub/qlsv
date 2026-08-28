using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Data
{
    public class NHibernateHelper
    {
        private ISessionFactory sessionFactory;
        public NHibernateHelper()
        {
            try
            {
                var configuration = Fluently.Configure()
                    .Database(MsSqlConfiguration
                    .MsSql2012
                    .ConnectionString
                    ("Server=(localdb)\\mssqllocaldb;Database=qlsvdb;Trusted_Connection=True;"))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<StudentMap>())
                    .BuildConfiguration();
                new NHibernate.Tool.hbm2ddl.SchemaUpdate(configuration).Execute(false, true);
                sessionFactory = configuration.BuildSessionFactory();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi tạo cơ sở dữ liệu: " + ex.ToString());
                throw;
            }
        }
        public ISession OpenSession()
        {
            return sessionFactory.OpenSession();
        }
    }
}
