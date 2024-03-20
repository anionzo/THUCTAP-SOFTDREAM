using StudentManagement.Data.Dapper;
using StudentManagement.Models;
using StudentManagement.Models.DapperModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interfaces.IData
{
    public interface IEnrolledCoursesStudentRegisterData: IReadData<EnrolledCoursesStudentRegister>, ICUDData<EnrolledCoursesStudentRegister>
    {
        DataTable GetListStudent_Fail_Pass(int IDEnrolledCourse);
        List<SubjectFailPass> GetSubjectFailPassList(string StudentID);
        List<CoursesRegistered> GetAllCoursesRegistered();
        List<EnrolledCoursesStudentRegister> GetAll(int id);
    }
}
