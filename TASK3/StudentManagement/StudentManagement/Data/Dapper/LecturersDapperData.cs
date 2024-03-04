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
        public bool Create(Lecturers entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Lecturers entity)
        {
            throw new NotImplementedException();
        }

        public Lecturers Get(object key)
        {
            throw new NotImplementedException();
        }

        public List<Lecturers> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Lecturers entity)
        {
            throw new NotImplementedException();
        }
    }
}
