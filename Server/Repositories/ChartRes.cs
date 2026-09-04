using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Server.Repositories
{
    internal class ChartRes : IChartRes
    {
        private readonly NHibernateHelper helper;
        public ChartRes(NHibernateHelper helper)
        {
            this.helper= helper;
        }
        public List<ChartData> BirthStudentCount()
        {
            using(var session =helper.OpenSession())
            {
                return session.Query<Student>()
                    .GroupBy(x=> x.DateBirthDay.Year)
                    .Select(x=> new ChartData
                    {
                        Category= x.Key.ToString(),
                        Value= x.Count()
                    })
                    .ToList();
            }
        }
        public List<ChartData> ClassStudentCount()
        {
            using (var session = helper.OpenSession())
            {
                return session.Query<Student>()
                    .Where(x => x.StudentClass != null)
                    .GroupBy(x => x.StudentClass.Name)
                    .Select(x => new ChartData
                    {
                        Category = x.Key.ToString(),
                        Value = x.Count()
                    })
                    .ToList();
            }
        }
        public List<BubbleData> SubjectRelation()
        {
            using(var session = helper.OpenSession())
            {
                return session.Query<Student>()
                    .Select(x=> new BubbleData
                    {
                        X=x.GpaMath,
                        Y=x.GpaEnglish,
                        Size=x.GpaLiterature
                    })
                    .ToList();
            }
        }
        public List<BulletData> SubjectTarget()
        {
            using(var session = helper.OpenSession())
            {
                var query = session.Query<Student>();
                var mathAvg= query.Average(x=> x.GpaMath);
                var englishAvg = query.Average(x => x.GpaEnglish);
                var literatureAvg = query.Average(x => x.GpaLiterature);
                return new List<BulletData>
                {
                    new()
                    {
                        Name="mathAvg",
                        Value=mathAvg,
                        Target=10
                    },
                     new()
                    {
                        Name="englishAvg",
                        Value=englishAvg,
                        Target=10
                    },
                      new()
                    {
                        Name="literatureAvg",
                        Value=literatureAvg,
                        Target=10
                    }
                };

            }
        }
        public List<ChartData> SubjectValueData()
        {
            using(var session1 = helper.OpenSession())
            {
                var query = session1.Query<Student>();
                var mathAvg = query.Average(x => x.GpaMath);
                var englishAvg = query.Average(x => x.GpaMath);
                var literatureAvg = query.Average(x => x.GpaMath);
                return new List<ChartData>
                {
                    new()
                    {
                        Category="mathAvg",
                        Value=mathAvg
                    },
                     new()
                    {
                        Category="englishAvg",
                        Value=englishAvg
                    },
                      new()
                    {
                        Category="literatureAvg",
                        Value=literatureAvg
                    }
                };
            }
        }
        public List<BulletData> ClassAverageGpaData()
        {
            using(var session1 = helper.OpenSession())
            {
                return session1.Query<Student>()
                    .GroupBy(x=>x.StudentClass)
                    .Select(x=> new BulletData
                    {
                        Name=x.Key.Name,
                        Value=x.Count(),
                        Target=Math.Round(
                            x.Average(x => x.GpaMath+x.GpaEnglish+x.GpaLiterature),2)
                    })
                    .ToList();
            }
        }
        public double AverageGpa()
        {
            using(var session1 = helper.OpenSession())
            {
                return Math.Round(session1.Query<Student>()
                    .Average(x => x.GpaMath + x.GpaEnglish + x.GpaLiterature),2);
            }
        }
        public List<ChartSeriesData> ClassSubjectAverageGpaData()
        {
            using(var session1= helper.OpenSession())
            {
                var x= session1.Query<Student>()
                    .GroupBy(x=>x.StudentClass)
                    .Select(x=> new 
                    {
                        ClassName = x.Key,
                        AvgMath = x.Average(s => s.GpaMath),
                        AvgLit = x.Average(s => s.GpaLiterature),
                        AvgEng = x.Average(s => s.GpaEnglish)
                    })
                    .ToList();
                var result = new List<ChartSeriesData>();
                foreach( var item in x)
                {
                    result.Add(new ChartSeriesData { Category = item.ClassName.ToString(), Series = "Toán", Value = Math.Round(item.AvgMath, 2) });
                    result.Add(new ChartSeriesData { Category = item.ClassName.ToString(), Series = "Văn", Value = Math.Round(item.AvgLit, 2) });
                    result.Add(new ChartSeriesData { Category = item.ClassName.ToString(), Series = "Anh", Value = Math.Round(item.AvgEng, 2) });
                }
                return result;
            }
        }
        public List<ChartData> BirthAverageGpa()
        {
            using (var session1 = helper.OpenSession())
            {
                return session1.Query<Student>()
                    .GroupBy(x => x.DateBirthDay.Year)
                    .Select(x => new ChartData
                    {
                        Category = x.Key.ToString(),
                        Value = x.Count()
                    })
                    .ToList();
            }
        }
        public double GpaTargeRateData()
        {
            using (var session1 = helper.OpenSession())
            {
                var query = session1.Query<Student>();

                int totalStudents = query.Count();
                if (totalStudents == 0) return 0.0; 

                int targetStudents = query.Count(x => (x.GpaMath + x.GpaEnglish + x.GpaLiterature) / 3.0 >= 8.0);

                return Math.Round((double)targetStudents / totalStudents, 2);
            }
        }
        public List<ChartData> ClassGpaRateData()
        {
            using(var session1 = helper.OpenSession())
            {
                return session1.Query<Student>()
                    .GroupBy(x => x.StudentClass.Name)
                    .Select(x => new ChartData
                    {
                        Category = x.Key,
                        Value = x.Count()
                    })
                    .ToList();
            }
        }
        public List<ChartSeriesData> StatusGpa()
        {
            using (var session1 = helper.OpenSession())
            {
                var x = session1.Query<Student>()
                   .GroupBy(x => x.Id)
                   .Select(x => new
                   {
                       ClassName = x.Key,
                       AvgMath = x.Average(s => s.GpaMath),
                       AvgLit = x.Average(s => s.GpaLiterature),
                       AvgEng = x.Average(s => s.GpaEnglish)
                   })
                   .ToList();
                var result = new List<ChartSeriesData>();
                foreach (var item in x)
                {
                    result.Add(new ChartSeriesData { Category = item.ClassName.ToString(), Series = "Toán", Value = Math.Round(item.AvgMath, 2) });
                    result.Add(new ChartSeriesData { Category = item.ClassName.ToString(), Series = "Văn", Value = Math.Round(item.AvgLit, 2) });
                    result.Add(new ChartSeriesData { Category = item.ClassName.ToString(), Series = "Anh", Value = Math.Round(item.AvgEng, 2) });
                }
                return result;
            }
        }
        public List<ChartPoint> RelationMathAndEnglish()
        {
            using (var session1 = helper.OpenSession())
            {
                return session1.Query<Student>()
                    .Select(x => new ChartPoint
                    {
                        X = x.GpaMath,
                        Y = x.GpaEnglish
                    })
                    .ToList();
            }
        }
    }
}
