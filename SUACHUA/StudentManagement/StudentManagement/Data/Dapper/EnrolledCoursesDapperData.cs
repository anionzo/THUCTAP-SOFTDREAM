using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using StudentManagement.Models.DapperModels;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentManagement.Data.Dapper
{
    internal class EnrolledCoursesDapperData : IEnrolledCoursesData
    {
        private readonly string _connectionString;
        SqlDataAccess<EnrolledCourses> _dataAccess;
        SqlDataDapperAccess<EnrolledCourses> _dataDapperAccess;
        public EnrolledCoursesDapperData(string connectionString)
        {
            this._connectionString = connectionString;
            _dataAccess = new SqlDataAccess<EnrolledCourses>(connectionString);
            _dataDapperAccess = new SqlDataDapperAccess<EnrolledCourses>(_connectionString);
        }
        public bool Create(EnrolledCourses entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EnrolledCourses entity)
        {
            throw new NotImplementedException();
        }

        public EnrolledCourses Get(object key)
        {
            //string query = $"select *  from TBL_EnrolledCourses where IDEnrolledCourses = {key}";

            //var datas = _dataAccess.ExecuteQuery(query);
            //if(datas.Rows.Count == 0)
            //{
            //    return null;
            //}
            //var list = Helper.ConvertDataTableToList<EnrolledCourses>(datas);
            //return list[0];

            string query = $"select *  from TBL_EnrolledCourses where IDEnrolledCourses = @IDEnrolledCourses";

            return _dataDapperAccess.Query(query,("IDEnrolledCourses", key)).FirstOrDefault();
        }

        public List<EnrolledCourses> GetAll()
        {
            //string query = $"select *  from TBL_EnrolledCourses";
            //var datas = _dataAccess.ExecuteQuery(query);

            //var list = Helper.ConvertDataTableToList<EnrolledCourses>(datas);
            //return list;

            string query = $"select *  from TBL_EnrolledCourses";
            return _dataDapperAccess.Query(query) ;
        }

        public List<CoursesRegistered> GetAllCoursesRegistered()
        {

            string query = "  SELECT ec.IDEnrolledCourses, se.*,su.NameSubject,su.Credits, su.CourseType,ec.StartDate, ec.EndDate\r\n    FROM TBL_Semester se\r\n    JOIN TBL_EnrolledCourses ec ON se.IDSemester = ec.IDSemester\r\n    JOIN TBL_Subject su ON su.IDSubject = ec.IDSubject";
            SqlDataDapperAccess<CoursesRegistered> sqlDataCR = new SqlDataDapperAccess<CoursesRegistered>(_connectionString);
            return sqlDataCR.Query(query);
        }

        public EnrolledCourseDetails GetEnrolledCourseDetails(int EnrolledCourseID)
        {
            string query = "SELECT * FROM GetEnrolledCourseDetails(@EnrolledCourseID)";
            (string, object)[] para = { ("@EnrolledCourseID", EnrolledCourseID) };
            SqlDataDapperAccess<EnrolledCourseDetails> sqlDataCR = new SqlDataDapperAccess<EnrolledCourseDetails>(_connectionString);
            return sqlDataCR.Query(query, para).FirstOrDefault();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(EnrolledCourses entity)
        {
            throw new NotImplementedException();
        }
    }
}
