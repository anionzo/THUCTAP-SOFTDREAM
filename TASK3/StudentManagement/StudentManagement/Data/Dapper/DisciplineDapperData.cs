using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Dapper
{
    internal class DisciplineDapperData : IDisciplineData
    {
        private readonly string _connectionString;
        public DisciplineDapperData(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public bool Create(Discipline entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Discipline entity)
        {
            throw new NotImplementedException();
        }

        public Discipline Get(object key)
        {
            throw new NotImplementedException();
        }

        public List<Discipline> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Discipline entity)
        {
            throw new NotImplementedException();
        }
    }
}
