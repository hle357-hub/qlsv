using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Repositories
{
    public interface IChartRes
    {
        List<ChartDataDto> BirthStudentCount();
        List<ChartDataDto> ClassStudentCount();
        List<BubbleDataDto> SubjectRelation();
        List<BulletDataDto> SubjectTarget();
        List<ChartDataDto> SubjectValueData();
        List<BulletDataDto> ClassAverageGpaData();
        double AverageGpa();
        List<ChartSeriesDataDto> ClassSubjectAverageGpaData();
        List<ChartDataDto> BirthAverageGpa();
        double GpaTargeRateData();
        List<ChartDataDto> ClassGpaRateData();
        List<ChartSeriesDataDto> StatusGpa();
        List<ChartPointDto> RelationMathAndEnglish();
    }
}
