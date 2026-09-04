using AutoMapper;

namespace Server.Grpc
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Teacher, TeacherDto>()
                .ReverseMap();

            CreateMap<StudentClass, ClassStudentDto>()
                .ReverseMap();

            CreateMap<Student, StudentDto>()
                .ReverseMap();

            CreateMap<StudentListRequestDto, StudentListRequest>()
                .ReverseMap();

            CreateMap<StudentListResult, StudentListDto>()
                .ReverseMap();

            CreateMap<BubbleDataDto, BubbleData>()
               .ReverseMap();

            CreateMap<BulletDataDto, BulletData>()
              .ReverseMap();

            CreateMap<ChartDataDto, ChartData>()
               .ReverseMap();

            CreateMap<ChartPointDto, ChartPoint>()
                .ReverseMap();

            CreateMap<ChartSeriesDataDto, ChartSeriesData>()
                .ReverseMap();

        }
    }
}
