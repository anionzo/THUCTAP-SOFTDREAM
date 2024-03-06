using StudentManagement.Data.Dapper;
using StudentManagement.Models;
using StudentManagement.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interfaces.IServices
{
    internal interface IEnrolledCoursesStudentRegisterService: IReadWrite<EnrolledCoursesStudentRegister>
    {
        void ShowListshowsubjectScoreboard(List<EnrolledCoursesStudentRegister> list);
        void ShowListStudent_Fail_Pass(DataTable dataTable);

    }
}
