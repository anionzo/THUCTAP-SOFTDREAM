using StudentManagement.Data.Dapper;
using StudentManagement.Models;
using StudentManagement.Models.DapperModels;
using StudentManagement.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interfaces.IServices
{
    public interface IEnrolledCoursesStudentRegisterService: IReadWrite<EnrolledCoursesStudentRegister>
    {
        List<StudentFailPass> GetListStudent_Fail_Pass(int IDEnrolledCourse);
        void Update(EnrolledCoursesStudentRegister emmt);

    }
}
