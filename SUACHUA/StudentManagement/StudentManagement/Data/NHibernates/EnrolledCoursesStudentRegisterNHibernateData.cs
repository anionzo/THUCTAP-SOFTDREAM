using NHibernate;
using StudentManagement.Data.Dapper;
using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using StudentManagement.Models.DapperModels;
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
    public class EnrolledCoursesStudentRegisterNHibernateData : IEnrolledCoursesStudentRegisterData
    {
        public bool Create(EnrolledCoursesStudentRegister entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EnrolledCoursesStudentRegister entity)
        {
            throw new NotImplementedException();
        }

        public EnrolledCoursesStudentRegister Get(object key)
        {
            using (NHibernate.ISession session = NHibernateSession.OpenSession())
            {

                return session.Query<EnrolledCoursesStudentRegister>().Where(x => x.IDEnrolledCourses.Equals(key)).FirstOrDefault();
            }
        }

        public List<EnrolledCoursesStudentRegister> GetAll()
        {

            using (NHibernate.ISession session = NHibernateSession.OpenSession())
            {

                return session.Query<EnrolledCoursesStudentRegister>().ToList();
            }
        }

        public List<CoursesRegistered> GetAllCoursesRegistered()
        {
            throw new NotImplementedException();
        }

        public DataTable GetListStudent_Fail_Pass(int IDEnrolledCourse)
        {

            using (ISession session = NHibernateSession.OpenSession())
            {
                try
                {
                    string queryString = $"select * from GetSubjectFailPass(:IDEnrolledCourse)";

                    var query = session.CreateSQLQuery(queryString).SetParameter("IDEnrolledCourse", IDEnrolledCourse);
                    var result = query.List();

                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("MSSV", typeof(string));
                    dataTable.Columns.Add("IDEnrolledCourses", typeof(int));
                    dataTable.Columns.Add("CourseWorkScore", typeof(decimal));
                    dataTable.Columns.Add("ExamScore", typeof(decimal));
                    dataTable.Columns.Add("TotalScore", typeof(decimal));
                    dataTable.Columns.Add("Result", typeof(string));

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

        public List<SubjectFailPass> GetSubjectFailPassList(string StudentID)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(EnrolledCoursesStudentRegister entity)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entity);
                        transaction.Commit();
                        return true;
                    }catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}
