using StudentManagement.Interfaces.IData;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    internal class StudenService : IStudentService
    {
        private readonly IStudentData _studentData;
        public StudenService (IStudentData studentData)
        {
            _studentData = studentData;
        }
        public void Add(Student emmt)
        {
            throw new NotImplementedException();
        }

        public void ShowList(List<Student> list)
        {
            throw new NotImplementedException();
        }
    }
}
