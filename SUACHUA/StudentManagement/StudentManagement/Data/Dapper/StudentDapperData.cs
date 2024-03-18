using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using StudentManagement.Models.DapperModels;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Dapper
{
    internal class StudentDapperData : IStudentData
    {   
        private readonly string _connectionString;
        private SqlDataAccess<Student> _dataAccess;
        private SqlDataDapperAccess<Student> _dataDapperAccess;
        public StudentDapperData(string connectionString) { 
            this._connectionString = connectionString;
            _dataAccess = new SqlDataAccess<Student>(_connectionString);
            _dataDapperAccess = new SqlDataDapperAccess<Student>(_connectionString);
        }
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

            //string query = $"select * from TBL_Student st where st.MSSV like '{key}'";
            //var student = _dataAccess.ExecuteQuery(query);
            //if(student.Rows.Count == 0)
            //{
            //    return null;
            //}
            //var list = Helper.ConvertDataTableToList<Student>(student);
            //return list[0];

            string query = $"select * from TBL_Student st where st.MSSV like '{key}'";
            var student = _dataDapperAccess.Query(query).FirstOrDefault();
            return student;
        }

        public List<Student> GetAll()
        {

            //string query = "select st.MSSV,st.NameStudenr,st.DayAdmission,st.DateOfBirth,st.Gender,st.Status from TBL_Student st";
            //var datatable = _dataAccess.ExecuteQuery(query);
            //var list = Helper.ConvertDataTableToList<Student>(datatable);
            //return list;

            string query = "select * from TBL_Student st";
            var students = _dataDapperAccess.Query(query);
            return students != null ? students: null;
        }
        public List<CoursesRegistered> GetAllCoursesRegistered(string idSemester, string mssv)
        {
            string query = $"SELECT * FROM dbo.GetCoursesRegistered(@SemesterID, @StudentID)";
            var _dataCoursesRegisteredDapperAccess = new SqlDataDapperAccess<CoursesRegistered>(_connectionString);

            var listdata = _dataCoursesRegisteredDapperAccess.Query(query, ("@SemesterID", idSemester), ("@StudentID", mssv));
            return listdata;
        }
        public DataTable GetEnrolledCourseInfoForStudent(string mssv)
        {
            //string query = "select* from GetEnrolledCourseInfoForStudent(@StudentID)";
            //return _dataAccess.ExecuteQuery(query,("@StudentID", mssv));

            string query = "select* from GetEnrolledCourseInfoForStudent(@StudentID)";
             
            var dataDapperAccess2 = new SqlDataDapperAccess<EnrolledCourseInfoForStudent>(_connectionString);
            var list = dataDapperAccess2.Query(query, ("StudentID", mssv));

            DataTable dataTable = new DataTable();
            dataTable = Helper.ConvertListToDataTable(list);
            return dataTable;
        }

        public double GetNumberSubjectRegister(string idSemester, string mssv)
        {
            string query = "SELECT dbo.GetNumberOfCoursesRegistered(@SemesterID, @StudentID)";
            (string, object)[] parameters = { ("@SemesterID", idSemester), ("@StudentID", mssv) };


            return _dataDapperAccess.ExecuteScalar(query, parameters);
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
