using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Dapper
{
    internal class UniversityDapperData : IUniversityData
    {
        private readonly string _connectionString;
        public UniversityDapperData(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public bool Create(University entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(University entity)
        {
            throw new NotImplementedException();
        }

        public University Get(object key)
        {
            throw new NotImplementedException();
        }

        public List<University> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(University entity)
        {
            throw new NotImplementedException();
        }
    }
}
