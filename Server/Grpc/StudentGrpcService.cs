using QuanLySinhVien.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Grpc
{
    public class StudentGrpcService : IQlsvService
    {
        private readonly Studentservice _service;
        public StudentGrpcService(Studentservice service)
        {
            this._service = service;
        }
        private StudentDto MapToStudentProto(Student item)
        {
            return new StudentDto
            {
                Id = item.Id,
                Name = item.Name,
                DateBirthDay = item.DateBirthDay,
                Address = item.Address,
                StudentClass = item.StudentClass == null ? null : new ClassStudentDto
                {
                    Id = item.StudentClass.Id,
                    Name = item.StudentClass.Name,
                    Subject = item.StudentClass.Subject,
                    Teacher = item.StudentClass.Teacher == null ? null : new TeacherDto
                    {
                        Id = item.StudentClass.Teacher.Id ?? "",
                        Name = item.StudentClass.Teacher.Name ?? ""
                    }
                }
            };
        }

        private Student MapToStudent(StudentDto item)
        {
            return new Student
            {
                Id = item.Id,
                Name = item.Name,
                DateBirthDay = item.DateBirthDay,
                Address = item.Address,
                StudentClass = item.StudentClass == null ? null : new StudentClass
                {
                    Id = item.StudentClass.Id,
                    Name = item.StudentClass.Name,
                    Subject = item.StudentClass.Subject,
                    Teacher = item.StudentClass.Teacher == null ? null : new Teacher
                    {
                        Id = item.StudentClass.Teacher.Id,
                        Name = item.StudentClass.Teacher.Name
                    }
                }
            };
        }
        private StudentListRequest MapToStudentListRequest(StudentListRequestDto request)
        {
            return new StudentListRequest
            {
                Keyword = request.Keyword,
                SortBy = request.SortBy,
                Descending = request.Descending,
                Page = request.Page,
                PageSize = request.PageSize
            };
        }
        public async Task<StudentListDto> StudentListAsync(StudentListRequestDto request)
        {
            var requestDto =MapToStudentListRequest(request);
            var studentList =await _service.StudentList(requestDto);

            return new StudentListDto
            {
                Students = studentList.Students
                    .Select(MapToStudentProto)
                    .ToList(),
                Total =studentList.Total
            };
        }
        public async Task<StatusDto> AddStudentAsync(StudentDto sv)
        {
            try
            {
                var student = MapToStudent(sv);
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
                var student = MapToStudent(sv);
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
                var student = MapToStudent(sv);
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
