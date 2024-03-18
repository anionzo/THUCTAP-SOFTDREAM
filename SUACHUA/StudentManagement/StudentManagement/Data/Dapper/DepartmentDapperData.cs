using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Dapper
{
    internal class DepartmentDapperData : IDepartmentData
    {
        private readonly string _connectionString;
        public DepartmentDapperData(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public bool Create(Department entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Department entity)
        {
            throw new NotImplementedException();
        }

        public Department Get(object key)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
