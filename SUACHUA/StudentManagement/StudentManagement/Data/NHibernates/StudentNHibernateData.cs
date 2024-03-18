using NHibernate;
using StudentManagement.Data.Dapper;
using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using ISession = NHibernate.ISession;

namespace StudentManagement.Data.NHibernates
{
    public class StudentNHibernateData : IStudentData
    {
        public bool Create(Student entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public Student Get(object key)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
               
                    return session.Query<Student>().Where(b => b.MSSV.Equals(key)).FirstOrDefault();

            }
        }

        public List<Student> GetAll()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                try
                {
                    var data = session.Query<Student>().
                        Select( x =>  new Student { 
                            MSSV = x.MSSV,
                            NameStudenr = x.NameStudenr,
                            DayAdmission = x.DayAdmission,
                            DateOfBirth = x.DateOfBirth,
                            Gender = x.Gender,
                            Status =x.Status
                        }).ToList();
                    return data;

                }
                catch (Exception ex) {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public List<CoursesRegistered> GetAllCoursesRegistered(string idSemester, string mssv)
        {
            throw new NotImplementedException();
        }

        public DataTable GetEnrolledCourseInfoForStudent(string mssv)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                try
                {
                    // Tạo câu truy vấn SQL tùy chỉnh
                    //// NHibernate không sử dụng @ => :
                    string queryString = "select * from GetEnrolledCourseInfoForStudent(:StudentID)"; // Ví dụ thực tế

                    // Tạo query
                    var query = session.CreateSQLQuery(queryString).SetParameter("StudentID", mssv);
                                      

                    // Thực thi truy vấn và lấy kết quả
                    var result = query.List();

                    // Chuyển đổi kết quả thành DataTable
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("MSSV", typeof(string));
                    dataTable.Columns.Add("IDEnrolledCourses", typeof(int));
                    dataTable.Columns.Add("CourseWorkScore", typeof(decimal));
                    dataTable.Columns.Add("ExamScore", typeof(decimal));
                    dataTable.Columns.Add("TotalScore", typeof(decimal));
                    dataTable.Columns.Add("NameSemester", typeof(string));
                    dataTable.Columns.Add("CourseworkWeight", typeof(decimal));
                    dataTable.Columns.Add("NameSubject", typeof(string));

                    // Thêm các cột khác nếu cần

                    foreach (object[] row in result)
                    {
                        dataTable.Rows.Add(row);
                    }

                    return dataTable;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }
        }

        public double GetNumberSubjectRegister(string idSemester, string mssv)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                try
                {
                    // Tạo câu truy vấn SQL tùy chỉnh
                    string queryString = "SELECT dbo.GetNumberOfCoursesRegistered(:SemesterID, :StudentID)";

                    // Tạo query
                    var query = session.CreateSQLQuery(queryString)
                                      .SetParameter("SemesterID", idSemester)
                                      .SetParameter("StudentID", mssv);

                    // Thực thi truy vấn và lấy kết quả
                    int numberOfCourses = (int)query.UniqueResult();

                    return numberOfCourses;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return -1;
                }
            }
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
