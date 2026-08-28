using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Data
{
    internal class DatabaseTestHelper
    {
        public static void BomDuLieuTest()
        {
            try
            {
                NHibernateHelper helper = new NHibernateHelper();

                using (var session = helper.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    var gv1 = new Teacher
                    {
                        Id = "GV01",
                        Name = "Thay Nguyen Van A",
                        DateBirthDay = new DateTime(1980, 1, 1)
                    };
                    var gv2 = new Teacher
                    {
                        Id = "GV02",
                        Name = "Thay Nguyen Van B",
                        DateBirthDay = new DateTime(1980, 1, 1)
                    };
                    var gv3 = new Teacher
                    {
                        Id = "GV03",
                        Name = "Thay Nguyen Van C",
                        DateBirthDay = new DateTime(1980, 1, 1)
                    };
                    List<StudentClass> students = new List<StudentClass>();
                    var lh1 = new StudentClass
                    {
                        Id = "LH01",
                        Name = "Lop CNTT K62",
                        Subject = "Lap trinh C",
                        Teacher = gv1
                    };

                    var lh2 = new StudentClass
                    {
                        Id = "LH02",
                        Name = "Lop CNTT K65",
                        Subject = "Lap trinh C#",
                        Teacher = gv2
                    };
                    var lh3 = new StudentClass
                    {
                        Id = "LH03",
                        Name = "Lop CNTT K64",
                        Subject = "Lap trinh C++",
                        Teacher = gv3
                    };
                    session.SaveOrUpdate(gv1);
                    session.SaveOrUpdate(gv2);
                    session.SaveOrUpdate(gv3);
                    session.SaveOrUpdate(lh1);
                    session.SaveOrUpdate(lh2);
                    session.SaveOrUpdate(lh3);
                    students.Add(lh1);
                    students.Add(lh2);
                    students.Add(lh3);
                    string[] ho =
                    {
                "Nguyen", "Tran", "Le", "Pham", "Hoang",
                "Phan", "Vu", "Vo", "Dang", "Bui"
            };

                    string[] tenDem =
                    {
                "Van", "Thi", "Duc", "Minh", "Thanh",
                "Ngoc", "Quang", "Anh", "Hoang", "Xuan"
            };

                    string[] ten =
                    {
                "An", "Binh", "Cuong", "Dung", "Huy",
                "Hung", "Khanh", "Long", "Nam", "Phuc"
            };

                    string[] diaChi =
                    {
                "Ha Noi",
                "Nam Dinh",
                "Hai Phong",
                "Da Nang",
                "Thanh Hoa",
                "Nghe An",
                "Bac Ninh",
                "Hai Duong",
                "Quang Ninh",
                "Ninh Binh"
            };
                    var random= new Random();
                    for (int i = 1; i <= 200; i++)
                    {
                        var sv = new Student
                        {
                            Id = $"SV{i:000}",
                            Name = $"{ho[random.Next(ho.Length)]} " +
                                   $"{tenDem[random.Next(tenDem.Length)]} " +
                                   $"{ten[random.Next(ten.Length)]}",
                            DateBirthDay = new DateTime(
                                random.Next(2000, 2006),
                                random.Next(1, 13),
                                random.Next(1, 29)
                            ),
                            Address = diaChi[random.Next(diaChi.Length)],
                            StudentClass = students[random.Next(students.Count)],
                            GpaEnglish=random.Next(0,11),
                            GpaMath = random.Next(0, 11),
                            GpaLiterature = random.Next(0, 11),
                        };

                        session.Save(sv);
                    }
                    transaction.Commit();

                    Console.WriteLine("Da them 100 sinh vien thanh cong!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }
    }
}

