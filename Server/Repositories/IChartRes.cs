using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Repositories
{
    public interface IChartRes
    {
        List<ChartData> BirthStudentCount();
        List<ChartData> ClassStudentCount();
        List<BubbleData> SubjectRelation();
        List<BulletData> SubjectTarget();
        List<ChartData> SubjectValueData();
        List<BulletData> ClassAverageGpaData();
        double AverageGpa();
        List<ChartSeriesData> ClassSubjectAverageGpaData();
        List<ChartData> BirthAverageGpa();
        double GpaTargeRateData();
        List<ChartData> ClassGpaRateData();
        List<ChartSeriesData> StatusGpa();
        List<ChartPoint> RelationMathAndEnglish();
    }
}
