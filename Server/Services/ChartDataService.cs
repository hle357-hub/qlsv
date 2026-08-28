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
        public List<ChartDataDto> BirthStudentCount()
        {
            return x.BirthStudentCount();
        }
        public List<ChartDataDto> ClassStudentCount()
        {
            return x.ClassStudentCount();
        }
        public List<BubbleDataDto> SubjectRelation()
        {
            return x.SubjectRelation();
        }
        public List<BulletDataDto> SubjectTarget()
        {
            return x.SubjectTarget();
        }
        public List<ChartDataDto> SubjectValueData()
        {
            return x.SubjectValueData();
        }
        public List<BulletDataDto> ClassAverageGpaData()
        {
            return x.ClassAverageGpaData();
        }
        public double AverageGpa()
        {
            return x.AverageGpa();
        }
        public List<ChartSeriesDataDto> ClassSubjectAverageGpaData()
        {
            return x.ClassSubjectAverageGpaData();
        }
        public List<ChartDataDto> BirthAverageGpa()
        {
            return x.BirthAverageGpa();
        }
        public double GpaTargeRateData()
        {
            return x.GpaTargeRateData();
        }
        public List<ChartDataDto> ClassGpaRateData()
        {
            return x.ClassGpaRateData();
        }
        public List<ChartSeriesDataDto> StatusGpa()
        {
            return x.StatusGpa();
        }
        public List<ChartPointDto> RelationMathAndEnglish()
        {
            return x.RelationMathAndEnglish();
        }
    }
}
