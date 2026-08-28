using ProtoBuf.Grpc.Configuration;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace QuanLySinhVien.Shared
{
    [DataContract]
    public class BubbleDataDto
    {
        [DataMember(Order = 1)]
        public double X { get; set; }
        [DataMember(Order = 2)]
        public double Y { get; set; }
        [DataMember(Order = 3)]
        public double Size { get; set; }
    }
    [DataContract]
    public class BulletDataDto
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
        [DataMember(Order = 2)]
        public double Value { get; set; }
        [DataMember(Order = 3)]
        public double Target { get; set; }
    }
    [DataContract]
    public class ChartDataDto
    {
        [DataMember(Order = 1)]
        public string Category { get; set; }
        [DataMember(Order = 2)]
        public double Value { get; set; }
    }
    [DataContract]
    public class ChartPointDto
    {
        [DataMember(Order = 1)]
        public double X { get; set; }
        [DataMember(Order = 2)]
        public double Y { get; set; }
    }
    [DataContract]
    public class ChartSeriesDataDto
    {
        [DataMember(Order = 1)]
        public string Category { get; set; }
        [DataMember(Order = 2)]
        public string Series { get; set; }
        [DataMember(Order = 3)]
        public double Value { get; set; }
    }
    [DataContract]
    public class ServiceListResponse<T>
    {
        [DataMember(Order = 1)]
        public List<T> Data { get; set; } = new();
        [DataMember(Order = 2)]
        public bool Success { get; set; } = true;
        [DataMember(Order = 3)]
        public string Message { get; set; } = String.Empty;
    }
   
    [DataContract]
    public class ValueDto
    {
        [DataMember(Order = 1)]
        public double Data { get; set; }
        [DataMember(Order = 2)]
        public bool Success { get; set; } = true;
        [DataMember(Order = 3)]
        public string Message { get; set; } = String.Empty;
    }
    [Service("b1._2.QlStudentService")]
    public interface IChartDataService
    {
        [Operation]
        public Task<ServiceListResponse<ChartDataDto>> BirthStudentCountAsync();
        [Operation]
        public Task<ServiceListResponse<ChartDataDto>> ClassStudentCountAsync();
        [Operation]
        public Task<ServiceListResponse<BubbleDataDto>> SubjectRelationAsync();
        [Operation]
        public Task<ServiceListResponse<BulletDataDto>> SubjectTargetAsync();
        [Operation]
        public Task<ServiceListResponse<ChartDataDto>> SubjectValueDataAsync();
        [Operation]
        public Task<ServiceListResponse<BulletDataDto>> ClassAverageGpaDataAsync();
        [Operation]
        public Task<ValueDto> AverageGpaAsync();
        [Operation]
        public Task<ServiceListResponse<ChartSeriesDataDto>> ClassSubjectAverageGpaDataAsync();
        [Operation]
        public Task<ServiceListResponse<ChartDataDto>> BirthAverageGpaAsync();
        [Operation]
        public Task<ValueDto> GpaTargeRateDataAsync();
        [Operation]
        public Task<ServiceListResponse<ChartDataDto>> ClassGpaRateDataAsync();
        [Operation]
        public Task<ServiceListResponse<ChartSeriesDataDto>> StatusGpaAsync();
        [Operation]
        public Task<ServiceListResponse<ChartPointDto>> RelationMathAndEnglishAsync();
    }
}
