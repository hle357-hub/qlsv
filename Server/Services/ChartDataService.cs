using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Services
{
    public class ChartDataService
    {
        public IChartRes x;
        public ChartDataService(IChartRes x)
        {
            this.x = x;
        }
        public List<ChartData> BirthStudentCount()
        {
            return x.BirthStudentCount();
        }
        public List<ChartData> ClassStudentCount()
        {
            return x.ClassStudentCount();
        }
        public List<BubbleData> SubjectRelation()
        {
            return x.SubjectRelation();
        }
        public List<BulletData> SubjectTarget()
        {
            return x.SubjectTarget();
        }
        public List<ChartData> SubjectValueData()
        {
            return x.SubjectValueData();
        }
        public List<BulletData> ClassAverageGpaData()
        {
            return x.ClassAverageGpaData();
        }
        public double AverageGpa()
        {
            return x.AverageGpa();
        }
        public List<ChartSeriesData> ClassSubjectAverageGpaData()
        {
            return x.ClassSubjectAverageGpaData();
        }
        public List<ChartData> BirthAverageGpa()
        {
            return x.BirthAverageGpa();
        }
        public double GpaTargeRateData()
        {
            return x.GpaTargeRateData();
        }
        public List<ChartData> ClassGpaRateData()
        {
            return x.ClassGpaRateData();
        }
        public List<ChartSeriesData> StatusGpa()
        {
            return x.StatusGpa();
        }
        public List<ChartPoint> RelationMathAndEnglish()
        {
            return x.RelationMathAndEnglish();
        }
    }
}
