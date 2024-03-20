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

        public List<EnrolledCoursesStudentRegister> GetAll(int id)
        {
            return _enrolledCoursesStudentRegisterDapperData.GetAll(id);
        }

        public List<CoursesRegistered> GetAllCoursesRegistered()
        {
            return _enrolledCoursesStudentRegisterDapperData.GetAllCoursesRegistered();
        }

        public List<SubjectFailPass> GetSubjectFailPassList(string StudentID)
        {
            return _enrolledCoursesStudentRegisterDapperData.GetSubjectFailPassList(StudentID);
        }

        //public List<StudentFailPass> GetSubjectFailPassList(int IDEnrolledCourse)
        //{
        //    return _enrolledCoursesStudentRegisterDapperData.GetSubjectFailPassList(IDEnrolledCourse);
        //}
        public void Update(EnrolledCoursesStudentRegister emmt)
        {
            _enrolledCoursesStudentRegisterDapperData.Update(emmt);
        }
    }
}
