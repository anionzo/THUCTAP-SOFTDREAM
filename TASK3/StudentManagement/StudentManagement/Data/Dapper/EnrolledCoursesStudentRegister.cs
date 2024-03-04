using StudentManagement.Interfaces.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Dapper
{
    internal class EnrolledCoursesStudentRegister : IEnrolledCoursesStudentRegisterData
    {
        private readonly string _connectionString;
        public EnrolledCoursesStudentRegister(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public bool Create(Models.EnrolledCoursesStudentRegister entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Models.EnrolledCoursesStudentRegister entity)
        {
            throw new NotImplementedException();
        }

        public Models.EnrolledCoursesStudentRegister Get(object key)
        {
            throw new NotImplementedException();
        }

        public List<Models.EnrolledCoursesStudentRegister> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Models.EnrolledCoursesStudentRegister entity)
        {
            throw new NotImplementedException();
        }
    }
}
