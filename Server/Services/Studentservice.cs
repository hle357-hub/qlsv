using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Services
{
    public class Studentservice
    {
        public IStudentRes reStudent;

        public Studentservice(IStudentRes reStudent)
        {
            this.reStudent = reStudent;
        }

        public Task <StudentListResult> StudentList(StudentListRequest student)
        {
            return reStudent.StudentListAsync(student);
        }
        
        public Task AddStudent(Student student)
        {
            return reStudent.AddStudentAsync(student);
        }

        public Task xoaaStudent(string id)
        {
            return reStudent.DeleteStudentAsync(id);
        }

        public Task UpdateStudent(Student student)
        {
            return reStudent.UpdateStudentAsync(student);
        }
    }
}
