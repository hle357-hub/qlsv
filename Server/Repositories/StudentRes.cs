using QuanLySinhVien.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using NHibernate.Linq;
namespace Server.Repositories
{
    public class StudentRes : IStudentRes
    {
        private readonly NHibernateHelper helper;
        public StudentRes(NHibernateHelper helper)
        {
            this.helper = helper;
        }
        public async Task<StudentListResult> StudentList(StudentListRequest request)
        {
            using (var session = helper.OpenSession())
            {
                var query = session.Query<Student>();
                if (!string.IsNullOrEmpty(request.Keyword))
                {
                    query = query
                        .Where(Student => Student.Name
                        .Contains(request.Keyword))
                        ;
                }
                var totalStudent= await query.CountAsync();
                var pageStudent= await query
                    .OrderBy(x=>x.Id)
                    .Skip((request.Page-1)*request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();
                return new StudentListResult
                {
                    Students = pageStudent,
                    Total = totalStudent
                };
            }
        }
        public async Task AddStudent(Student student)
        {
            using (var session = helper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    if (await  session.GetAsync<Student>(student.Id) != null) {
                        throw new Exception("trung id sinh vien");
                    }
                    await session.SaveAsync(student);
                    await tx.CommitAsync();
                }
            }
        }
        public async Task UpdateStudent(Student student)
        {
            using (var session = helper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    await session.SaveOrUpdateAsync(student);
                    await tx.CommitAsync();
                }
            }
        }
        public async Task DeleteStudent(string id)
        {
            using (var session = helper.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    var student = await session.GetAsync<Student>(id);
                    if(student == null)
                    {
                        throw new Exception("khong tim thay sinh vien");
                    }
                    await session.DeleteAsync(student);
                    await tx.CommitAsync();
                }
            }
        }
    }
}
