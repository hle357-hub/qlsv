using ProtoBuf.Grpc.Configuration;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ProtoBuf.Grpc;
using ProtoBuf.Grpc.Configuration;

namespace QuanLySinhVien.Shared
{

    [DataContract]
    public class StudentDto
    {
        [DataMember(Order = 1)]
        public string Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        public DateTime DateBirthDay { get; set; }
        
        [DataMember(Order = 4)]
        public string Address { get; set; }
        [DataMember(Order = 5)]
        public ClassStudentDto StudentClass { get; set; }

    }
    [DataContract]
    public class TeacherDto
    {
        [DataMember(Order = 1)]
        public string Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }
        [DataMember(Order = 3)]
        public DateTime DateBirthDay { get; set; }
    }
    [DataContract]
    public class ClassStudentDto
    {
        [DataMember(Order = 1)]
        public string Id { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }
        [DataMember(Order = 3)]
        public string Subject { get; set; }
        [DataMember(Order = 4)]
        public TeacherDto Teacher { get; set; }
    }
    [DataContract]
    public class StudentListDto
    {
        [DataMember(Order = 1)]
        public List<StudentDto> Students { get; set; }
        [DataMember(Order =2)]
        public int Total {  get; set; }
    }
    [DataContract]
    public class StatusDto
    {
        [DataMember(Order =1)]
        public bool Success {  get; set; }
        [DataMember(Order =2)]
        public string Message { get; set; }
    }

    [DataContract]
    public class StudentListRequestDto
    {
        [DataMember(Order =1)]
        public string Keyword { get; set; }
        [DataMember(Order =2)]
        public string SortBy { get; set; }
        [DataMember(Order = 3)]
        public bool Descending { get; set; }
        [DataMember(Order = 4)]
        public int Page { get; set; }
        [DataMember(Order = 5)]
        public int PageSize { get; set; }
    }
    
    [Service("b1._2.QlStudentService")]
    public interface IQlsvService
    {
        [Operation]
        public Task<StudentListDto> StudentListAsync(StudentListRequestDto request);
        [Operation]
        public Task<StatusDto> AddStudentAsync(StudentDto student);
        [Operation]
        public Task<StatusDto> DeleteStudentAsync(StudentDto student);
        [Operation]
        public Task<StatusDto> UpdateStudentAsync(StudentDto student);
    }
}
