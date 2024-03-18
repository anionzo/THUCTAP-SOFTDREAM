using Castle.Windsor;
using Castle.Windsor.Installer;
using StudentManagement.Data.Dapper;
using StudentManagement.Interfaces.IData;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
using StudentManagement.Models.DapperModels;
using StudentManagement.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    public class EnrolledCoursesStudentRegisterService : IEnrolledCoursesStudentRegisterService
    {
        WindsorContainer container = new WindsorContainer();
        IEnrolledCoursesStudentRegisterData _enrolledCoursesStudentRegisterDapperData;
        public EnrolledCoursesStudentRegisterService(IEnrolledCoursesStudentRegisterData enrolledCoursesStudentRegisterDapperData)
        {
            _enrolledCoursesStudentRegisterDapperData = enrolledCoursesStudentRegisterDapperData;
        }
        public void Add(EnrolledCoursesStudentRegister emmt)
        {
            throw new NotImplementedException();
        }
        public List<StudentFailPass> GetListStudent_Fail_Pass(int IDEnrolledCourse)
        {
            return _enrolledCoursesStudentRegisterDapperData.GetStudent_Fail_PassList(IDEnrolledCourse);
        }
        public void Update(EnrolledCoursesStudentRegister emmt)
        {
            _enrolledCoursesStudentRegisterDapperData.Update(emmt);
        }
    }
}
