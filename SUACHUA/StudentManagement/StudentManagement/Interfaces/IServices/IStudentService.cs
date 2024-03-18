using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interfaces.IServices
{
    public interface IStudentService : IReadWrite<Student>
    {
        Student Get(object key);
        List<Student> GetAll();
        List<CoursesRegistered> GetAllCoursesRegistered(string idSemester, string mssv);
        DataTable GetEnrolledCourseInfoForStudent(string mssv);
        double GetNumberSubjectRegister(string idSemester, string mssv);
    }
}
