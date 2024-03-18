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
        private SqlDataDapperAccess<Subject> _dataDapperAccess;
        
        public SubjectDapperData(string connectionString)
        {
            this._connectionString = connectionString;
            _dataAccess = new SqlDataAccess<Subject>(connectionString);
            _dataDapperAccess = new SqlDataDapperAccess<Subject>(connectionString);
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
            //string query = "select * from TBL_Subject su";
            //var datatable = _dataAccess.ExecuteQuery(query);
            //var list = Helper.ConvertDataTableToList<Subject>(datatable);
            
            
            string query = "select * from TBL_Subject su";
            var list = _dataDapperAccess.Query(query);
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
