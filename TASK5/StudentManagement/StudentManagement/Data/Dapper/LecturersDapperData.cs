using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Dapper
{
    internal class LecturersDapperData : ILecturersData
    {
        private readonly string _connectionString;
        public LecturersDapperData(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public bool Create(Lecturer entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Lecturer entity)
        {
            throw new NotImplementedException();
        }

        public Lecturer Get(object key)
        {
            throw new NotImplementedException();
        }

        public List<Lecturer> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Lecturer entity)
        {
            throw new NotImplementedException();
        }
    }
}
