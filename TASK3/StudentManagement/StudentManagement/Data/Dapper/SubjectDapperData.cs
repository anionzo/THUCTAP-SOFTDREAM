using StudentManagement.Interfaces.IData;
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
        public SubjectDapperData(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public bool Create(ISubjectData entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ISubjectData entity)
        {
            throw new NotImplementedException();
        }

        public ISubjectData Get(object key)
        {
            throw new NotImplementedException();
        }

        public List<ISubjectData> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(ISubjectData entity)
        {
            throw new NotImplementedException();
        }
    }
}
