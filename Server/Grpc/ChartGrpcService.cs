using NHibernate.Linq;
using ProtoBuf.Grpc.Configuration;
using QuanLySinhVien.Shared;
using System;
using System.Collections.Generic;
using System.Text;
namespace Server.Grpc
{
    internal class ChartGrpcService: IChartDataService
    {
        private readonly ChartDataService service;
        public ChartGrpcService(ChartDataService service)
        {
            this.service = service;
        }
        public async Task<ServiceListResponse<ChartDataDto>> BirthStudentCountAsync()
        {
            var x = service.BirthStudentCount();
            return await Task.FromResult(new ServiceListResponse<ChartDataDto> 
            { Data = x, Success=true,Message="thanh cong" });
        }
        public async Task<ServiceListResponse<ChartDataDto>> ClassStudentCountAsync()
        {
            var x = service.ClassStudentCount();
            return await Task.FromResult(new ServiceListResponse<ChartDataDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<BubbleDataDto>> SubjectRelationAsync()
        {
            var x = service.SubjectRelation();
            return await Task.FromResult(new ServiceListResponse<BubbleDataDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<BulletDataDto>> SubjectTargetAsync()
        {
            var x = service.SubjectTarget();
            return await Task.FromResult(new ServiceListResponse<BulletDataDto>
            {
            Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<ChartDataDto>> SubjectValueDataAsync()
        {
            var x = service.SubjectValueData();
            return await Task.FromResult(new ServiceListResponse<ChartDataDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<BulletDataDto>> ClassAverageGpaDataAsync()
        {
            var x = service.ClassAverageGpaData();
            return await Task.FromResult(new ServiceListResponse<BulletDataDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ValueDto> AverageGpaAsync()
        {
            var x = service.AverageGpa();
            return await Task.FromResult(new ValueDto
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<ChartSeriesDataDto>> ClassSubjectAverageGpaDataAsync()
        {
            var x = service.ClassSubjectAverageGpaData();
            return await Task.FromResult(new ServiceListResponse<ChartSeriesDataDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<ChartDataDto>> BirthAverageGpaAsync()
        {
            var x = service.BirthAverageGpa();
            return await Task.FromResult(new ServiceListResponse<ChartDataDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ValueDto> GpaTargeRateDataAsync()
        {
            var x = service.GpaTargeRateData();
            return await Task.FromResult(new ValueDto
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<ChartDataDto>> ClassGpaRateDataAsync()
        {
            var x = service.ClassGpaRateData();
            return await Task.FromResult(new ServiceListResponse<ChartDataDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<ChartSeriesDataDto>> StatusGpaAsync()
        {
            var x = service.StatusGpa();
            return await Task.FromResult(new ServiceListResponse<ChartSeriesDataDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<ChartPointDto>> RelationMathAndEnglishAsync()
        {
            var x = service.RelationMathAndEnglish();
            return await Task.FromResult(new ServiceListResponse<ChartPointDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
    }
}
