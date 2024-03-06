using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interfaces.IServices
{
    internal interface IStudentService : IReadWrite<Student>
    {
        void ShowStudent(Student student);
        void ShowNumberSubjectRegister(double number);
        void ShowEnrolledCourseInfoForStudent(DataTable dataTable);
    }
}
