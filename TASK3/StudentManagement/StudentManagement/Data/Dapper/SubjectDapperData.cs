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
    internal class SubjectDapperData : ISubjectData
    {
        private readonly string _connectionString;
        private SqlDataAccess<Subject> _dataAccess; 
        
        public SubjectDapperData(string connectionString)
        {
            this._connectionString = connectionString;
            _dataAccess = new SqlDataAccess<Subject>(connectionString);
        }
        public bool Create(Subject entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Subject entity)
        {
            throw new NotImplementedException();
        }

        public Subject Get(object key)
        {
            throw new NotImplementedException();
        }

        public List<Subject> GetAll()
        {
            string query = "select su.IDSubject, su.Credits, su.CourseworkWeight, su.CourseType, su.NameSubject from TBL_Subject su";
            var datatable = _dataAccess.ExecuteQuery(query);
            var list = Helper.ConvertDataTableToList<Subject>(datatable);
            return list;
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Subject entity)
        {
            throw new NotImplementedException();
        }
    }
}
