using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Dapper
{
    internal class EnrolledCoursesStudentRegisterDapperData : IEnrolledCoursesStudentRegisterData
    {
        private readonly string _connectionString;
        SqlDataAccess<EnrolledCoursesStudentRegister> _dataAccess;
        public EnrolledCoursesStudentRegisterDapperData(string connectionString) {
        
            this._connectionString = connectionString;
            _dataAccess = new SqlDataAccess<EnrolledCoursesStudentRegister>(connectionString);

        }

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
            string query = $"select * from TBL_EnrolledCourses_Student_Register where IDEnrolledCourses = {key}";
            var dataTable = _dataAccess.ExecuteQuery(query);
            if (dataTable.Rows.Count > 0)
            {
                var data = Helper.ConvertDataTableToList<EnrolledCoursesStudentRegister>(dataTable);
                return data[0];
            }
            return null;
        }

        public List<EnrolledCoursesStudentRegister> GetAll()
        {
            string query = $"select * from TBL_EnrolledCourses_Student_Register";
            var dataTable = _dataAccess.ExecuteQuery(query);
            if(dataTable.Rows.Count > 0)
            {
                return Helper.ConvertDataTableToList<EnrolledCoursesStudentRegister>(dataTable);
            }
            return null;

        }

        public DataTable GetListStudent_Fail_Pass(int IDEnrolledCourse)
        {
            string query = $"select * from GetSubjectFailPass({IDEnrolledCourse})";
            var dataTable = _dataAccess.ExecuteQuery(query);
            if(dataTable.Rows.Count > 0)
            {
                return dataTable;
            }
            return null;
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(EnrolledCoursesStudentRegister entity)
        {
            string query = "UPDATE TBL_EnrolledCourses_Student_Register SET CourseWorkScore = @CourseWorkScore, ExamScore= @ExamScore WHERE MSSV = @MSSV AND IDEnrolledCourses = @IDEnrolledCourses";
            (string, object)[] parameters = { ("@CourseWorkScore", entity.CourseWorkScore),
                                              ("@ExamScore", entity.ExamScore), 
                                              ("@MSSV", entity.MSSV), 
                                              ("@IDEnrolledCourses", entity.IDEnrolledCourses) };
            var result = _dataAccess.ExecuteNonQuery(query,parameters);
            return result;

        }
    }
}
