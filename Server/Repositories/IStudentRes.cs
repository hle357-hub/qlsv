using QuanLySinhVien.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Repositories
{
    public interface IStudentRes
    {
        Task AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(string id);
        Task<StudentListResult> StudentList(
            StudentListRequest request
            );
    }
}
