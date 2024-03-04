using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Dapper
{
    internal class SemesterDapperData : ISemesterData
    {
        private readonly string _connectionString;
        public SemesterDapperData(string connectionString)
        {
            this._connectionString = connectionString;
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
            throw new NotImplementedException();
        }

        public List<Semester> GetAll()
        {
            throw new NotImplementedException();
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
