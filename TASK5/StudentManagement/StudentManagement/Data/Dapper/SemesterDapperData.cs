using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Dapper
{
    internal class SemesterDapperData : ISemesterData
    {
        private readonly string _connectionString;
        private SqlDataAccess<Semester> _dataAccess;
        public SemesterDapperData(string connectionString)
        {
            this._connectionString = connectionString;
            _dataAccess = new SqlDataAccess<Semester>(_connectionString);
        }
        public bool Create(Semester entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Semester entity)
        {
            throw new NotImplementedException();
        }

        public Semester Get(object key)
        {
            string query = $"select * from TBL_Semester where IDSemester = {key}";
            var dataTable = _dataAccess.ExecuteQuery(query);
            if(dataTable.Rows.Count == 0)
            {
                return null;
            }
            var listSemester = Helper.ConvertDataTableToList<Semester>(dataTable);
            return listSemester[0];
        }

        public List<Semester> GetAll()
        {
            string query = "select * from TBL_Semester";
            var dataTable = _dataAccess.ExecuteQuery(query);
            var listSemester = Helper.ConvertDataTableToList<Semester>(dataTable);
            return listSemester;
        }
            
        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Semester entity)
        {
            throw new NotImplementedException();
        }
    }
}
