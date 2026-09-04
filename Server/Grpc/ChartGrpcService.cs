using NHibernate.Linq;
using ProtoBuf.Grpc.Configuration;
using QuanLySinhVien.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace Server.Grpc
{
    internal class ChartGrpcService: IChartDataService
    {
        private readonly ChartDataService service;
        private readonly IMapper mapper;
        public ChartGrpcService(ChartDataService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<ServiceListResponse<ChartDataDto>> BirthStudentCountAsync()
        {
            var x = mapper.Map<List<ChartDataDto>>(service.BirthStudentCount());
            return await Task.FromResult(new ServiceListResponse<ChartDataDto> 
            { Data = x, Success=true,Message="thanh cong" });
        }
        public async Task<ServiceListResponse<ChartDataDto>> ClassStudentCountAsync()
        {
            var x = mapper.Map<List<ChartDataDto>>(service.ClassStudentCount());
            return await Task.FromResult(new ServiceListResponse<ChartDataDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<BubbleDataDto>> SubjectRelationAsync()
        {
            var x = mapper.Map<List<BubbleDataDto>>(service.SubjectRelation());
            return await Task.FromResult(new ServiceListResponse<BubbleDataDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<BulletDataDto>> SubjectTargetAsync()
        {
            var x = mapper.Map<List<BulletDataDto>>(service.SubjectTarget());
            return await Task.FromResult(new ServiceListResponse<BulletDataDto>
            {
            Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<ChartDataDto>> SubjectValueDataAsync()
        {
            var x = mapper.Map<List<ChartDataDto>>(service.SubjectValueData());
            return await Task.FromResult(new ServiceListResponse<ChartDataDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<BulletDataDto>> ClassAverageGpaDataAsync()
        {
            var x = mapper.Map<List<BulletDataDto>>(service.ClassAverageGpaData());
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
            var x = mapper.Map<List<ChartSeriesDataDto>>(service.ClassSubjectAverageGpaData());
            return await Task.FromResult(new ServiceListResponse<ChartSeriesDataDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<ChartDataDto>> BirthAverageGpaAsync()
        {
            var x = mapper.Map<List<ChartDataDto>>(service.BirthAverageGpa());
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
            var x = mapper.Map<List<ChartDataDto>>(service.ClassGpaRateData());
            return await Task.FromResult(new ServiceListResponse<ChartDataDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<ChartSeriesDataDto>> StatusGpaAsync()
        {
            var x = mapper.Map<List<ChartSeriesDataDto>>(service.StatusGpa()    );
            return await Task.FromResult(new ServiceListResponse<ChartSeriesDataDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
        public async Task<ServiceListResponse<ChartPointDto>> RelationMathAndEnglishAsync()
        {
            var x = mapper.Map<List<ChartPointDto>>(service.RelationMathAndEnglish());
            return await Task.FromResult(new ServiceListResponse<ChartPointDto>
            {
                Data = x,
                Success = true,
                Message = "thanh cong"
            });
        }
    }
}
