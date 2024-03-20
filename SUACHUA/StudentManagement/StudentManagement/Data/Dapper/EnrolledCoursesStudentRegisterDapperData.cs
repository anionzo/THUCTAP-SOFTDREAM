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
using static Dapper.SqlMapper;

namespace StudentManagement.Data.Dapper
{
    internal class EnrolledCoursesStudentRegisterDapperData : IEnrolledCoursesStudentRegisterData
    {
        private readonly string _connectionString;
        SqlDataAccess<EnrolledCoursesStudentRegister> _dataAccess;
        SqlDataDapperAccess<EnrolledCoursesStudentRegister> _dataDapperAccess;
        public EnrolledCoursesStudentRegisterDapperData(string connectionString) {
        
            this._connectionString = connectionString;
            _dataAccess = new SqlDataAccess<EnrolledCoursesStudentRegister>(connectionString);
            _dataDapperAccess = new SqlDataDapperAccess<EnrolledCoursesStudentRegister> (_connectionString);

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
            //string query = $"select * from TBL_EnrolledCourses_Student_Register where IDEnrolledCourses = {key}";
            //var dataTable = _dataAccess.ExecuteQuery(query);
            //if (dataTable.Rows.Count > 0)
            //{
            //    var data = Helper.ConvertDataTableToList<EnrolledCoursesStudentRegister>(dataTable);
            //    return data[0];
            //}
            //return null;

            string query = $"select * from TBL_EnrolledCourses_Student_Register where IDEnrolledCourses = {key}";
            return _dataDapperAccess.Query(query).FirstOrDefault();
        }

        public List<EnrolledCoursesStudentRegister> GetAll()
        {
            //string query = $"select * from TBL_EnrolledCourses_Student_Register";
            //var dataTable = _dataAccess.ExecuteQuery(query);
            //if(dataTable.Rows.Count > 0)
            //{
            //    return Helper.ConvertDataTableToList<EnrolledCoursesStudentRegister>(dataTable);
            //}
            //return null;
            
            string query = $"select * from TBL_EnrolledCourses_Student_Register";
            return _dataDapperAccess.Query(query);

        }

        public List<EnrolledCoursesStudentRegister> GetAll(int id)
        {

            string query = $"select * from TBL_EnrolledCourses_Student_Register where IDEnrolledCourses = {id}";
            return _dataDapperAccess.Query(query);
        }

        public List<CoursesRegistered> GetAllCoursesRegistered()
        {
            string query = "  SELECT se.*,su.NameSubject,su.Credits, su.CourseType,ec.StartDate, ec.EndDate\r\n    FROM TBL_Semester se\r\n    JOIN TBL_EnrolledCourses ec ON se.IDSemester = ec.IDSemester\r\n    JOIN TBL_Subject su ON su.IDSubject = ec.IDSubject";
            SqlDataDapperAccess<CoursesRegistered> sqlDataCR = new SqlDataDapperAccess<CoursesRegistered>(_connectionString);
            return sqlDataCR.Query(query);

        }

        public DataTable GetListStudent_Fail_Pass(int IDEnrolledCourse)
        {
            //string query = $"select * from GetSubjectFailPass({IDEnrolledCourse})";
            //var dataTable = _dataAccess.ExecuteQuery(query);
            //if(dataTable.Rows.Count > 0)
            //{
            //    return dataTable;
            //}
            //return null;

            string query = $"select * from GetSubjectFailPass({IDEnrolledCourse})";
            SqlDataDapperAccess<StudentFailPass> sqlData = new SqlDataDapperAccess<StudentFailPass>(_connectionString);
            DataTable dataTable = new DataTable();
            dataTable = Helper.ConvertListToDataTable(sqlData.Query(query));

            return dataTable;
        }

        public List<SubjectFailPass> GetSubjectFailPassList(string StudentID)
        {
            string query = $"select * from GetSubjectFailPass(@StudentID)";
            (string, object)[] parameters = { ("@StudentID", StudentID) };
            SqlDataDapperAccess<SubjectFailPass> sqlData = new SqlDataDapperAccess<SubjectFailPass>(_connectionString);
            return sqlData.Query(query,parameters);
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(EnrolledCoursesStudentRegister entity)
        {
            //string query = "UPDATE TBL_EnrolledCourses_Student_Register SET CourseWorkScore = @CourseWorkScore, ExamScore= @ExamScore WHERE MSSV = @MSSV AND IDEnrolledCourses = @IDEnrolledCourses";
            //(string, object)[] parameters = { ("@CourseWorkScore", entity.CourseWorkScore),
            //                                  ("@ExamScore", entity.ExamScore), 
            //                                  ("@MSSV", entity.MSSV), 
            //                                  ("@IDEnrolledCourses", entity.IDEnrolledCourses) };
            //var result = _dataAccess.ExecuteNonQuery(query,parameters);
            //return result;

            string query = "UPDATE TBL_EnrolledCourses_Student_Register SET CourseWorkScore = @CourseWorkScore, ExamScore= @ExamScore WHERE MSSV = @MSSV AND IDEnrolledCourses = @IDEnrolledCourses";
            (string, object)[] parameters = { ("@CourseWorkScore", entity.CourseWorkScore),
                                              ("@ExamScore", entity.ExamScore),
                                              ("@MSSV", entity.MSSV),
                                              ("@IDEnrolledCourses", entity.IDEnrolledCourses) };
            var result = _dataDapperAccess.Excute(query,parameters);
            return result;
        }
    }
}
