using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Dapper
{
    internal class StudentDapperData : IStudentData
    {   
        private readonly string _connectionString;
        private SqlDataAccess<Student> _dataAccess;
        public StudentDapperData(string connectionString) { 
            this._connectionString = connectionString;
            _dataAccess = new SqlDataAccess<Student>(_connectionString);
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

            string query = $"select * from TBL_Student st where st.MSSV like '{key}'";
            var student = _dataAccess.ExecuteQuery(query);
            if(student.Rows.Count == 0)
            {
                return null;
            }
            var list = Helper.ConvertDataTableToList<Student>(student);
            return list[0];
        }

        public List<Student> GetAll()
        {
            //string query = "SELECT * FROM TBL_Student";
            string query = "select st.MSSV,st.NameStudenr,st.DayAdmission,st.DateOfBirth,st.Gender,st.Status from TBL_Student st";
            var datatable = _dataAccess.ExecuteQuery(query);
            var list = Helper.ConvertDataTableToList<Student>(datatable);
            return list;
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
