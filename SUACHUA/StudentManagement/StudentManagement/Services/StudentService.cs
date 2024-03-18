using StudentManagement.Data.Dapper;
using StudentManagement.Interfaces.IData;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    public class StudentService : IStudentService
    {

        private readonly IStudentData _studentData;
        public StudentService (IStudentData studentData)
        {
            _studentData = studentData;
        }

        public void Add(Student emmt)
        {
            throw new NotImplementedException();
        }

        public Student Get(object key)
        {
            return _studentData.Get(key);
        }

        public List<Student> GetAll()
        {
            return _studentData.GetAll();
        }

        public List<CoursesRegistered> GetAllCoursesRegistered(string idSemester, string mssv)
        {
           return _studentData.GetAllCoursesRegistered(idSemester, mssv); 
        }

        public DataTable GetEnrolledCourseInfoForStudent(string mssv)
        {
            return _studentData.GetEnrolledCourseInfoForStudent(mssv);
        }

        public double GetNumberSubjectRegister(string idSemester, string mssv)
        {
            return _studentData.GetNumberSubjectRegister(idSemester, mssv);
        }
        public void ShowList(List<Student> list)
        {
            throw new NotImplementedException();
        }
    }
}
