using QuanLySinhVien.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace Server.Grpc
{
    public class StudentGrpcService : IQlsvService
    {
        private readonly Studentservice _service;
        private readonly IMapper _mapper;
        public StudentGrpcService(Studentservice service, IMapper mappe)
        {
            this._service = service;
            this._mapper = mappe;
        }
        
        
        public async Task<StudentListDto> StudentListAsync(StudentListRequestDto request)
        {
            var requestDto =_mapper.Map<StudentListRequest>(request);
            var studentList =await _service.StudentList(requestDto);

            return new StudentListDto
            {
                Students = _mapper.Map<List<StudentDto>>(studentList.Students),
                Total =studentList.Total
            };
        }
        public async Task<StatusDto> AddStudentAsync(StudentDto sv)
        {
            try
            {
                var student = _mapper.Map<Student>(sv);
                await _service.AddStudent(student);
                return new StatusDto { 
                    Success = true, 
                    Message = "Thêm sinh viên thành công" };
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.Message);
                return new StatusDto {
                    Success = false,
                    Message="them sinh vien that bai"
                };
            }
        }
        public async Task<StatusDto> DeleteStudentAsync(StudentDto sv)
        {
            try
            {
                var student = _mapper.Map<Student>(sv);
                await _service.xoaaStudent(student.Id);
                return new StatusDto { Success = true, Message = "Xóa sinh viên thành công" };
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new StatusDto {
                    Success= false,
                    Message="xoa sinh vien that bai"
                };
            }
        }
        public async Task<StatusDto> UpdateStudentAsync(StudentDto sv)
        {
            try
            {
                var student = _mapper.Map<Student>(sv);
                await _service.UpdateStudent(student);
                return new StatusDto { Success = true, Message = "Cập nhật sinh viên thành công" };
            }
            catch(Exception ex ) 
            {
                Console.WriteLine(ex.ToString());
                return new StatusDto { 
                    Success=false,
                    Message="cap nhat sinh vien that bai"
                };
            }
        }
    }
}
