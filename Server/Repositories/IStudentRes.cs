using QuanLySinhVien.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Repositories
{
    public interface IStudentRes
    {
        Task AddStudentAsync(Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(string id);
        Task<StudentListResult> StudentListAsync(
            StudentListRequest request
            );
    }
}
