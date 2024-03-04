using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.Dapper
{
    internal class EnrolledCoursesDapperData : IEnrolledCoursesData
    {
        private readonly string _connectionString;
        public EnrolledCoursesDapperData(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public bool Create(EnrolledCourses entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EnrolledCourses entity)
        {
            throw new NotImplementedException();
        }

        public EnrolledCourses Get(object key)
        {
            throw new NotImplementedException();
        }

        public List<EnrolledCourses> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(EnrolledCourses entity)
        {
            throw new NotImplementedException();
        }
    }
}
