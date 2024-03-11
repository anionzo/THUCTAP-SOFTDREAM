using Castle.Windsor;
using Castle.Windsor.Installer;
using StudentManagement.Data.Dapper;
using StudentManagement.Interfaces.IData;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
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
    internal class EnrolledCoursesStudentRegisterService : IEnrolledCoursesStudentRegisterService
    {
        WindsorContainer container = new WindsorContainer();
        IEnrolledCoursesStudentRegisterData enrolledCoursesStudentRegisterDapperData;
        public EnrolledCoursesStudentRegisterService()
        {
            container.Install(FromAssembly.This());
            enrolledCoursesStudentRegisterDapperData = container.Resolve<IEnrolledCoursesStudentRegisterData>();
        }
        public void Add(EnrolledCoursesStudentRegister emmt)
        {
            enrolledCoursesStudentRegisterDapperData.Update(emmt);
        }

        public void ShowList(List<EnrolledCoursesStudentRegister> list)
        {
            throw new NotImplementedException();
        }
        public void ShowListshowsubjectScoreboard(List<EnrolledCoursesStudentRegister> list)
        {
            List<string> listNameHeader = new List<string> {
                            "Mssv","Mã DP ĐK","Điểm QT","Điểm thi", "Điểm tổng"
                        };
            HelperPrint.PrintTable(list, listNameHeader);

        }

        public void ShowListStudent_Fail_Pass(DataTable dataTable)
        {
            List<string> listNameHeader = new List<string> {
                            "Mssv","Mã DP ĐK","Điểm QT","Điểm thi", "Điểm tổng","Kết Quả"
                        };
            HelperPrint.PrintDataTable(dataTable, listNameHeader);
        }

        public void Update(EnrolledCoursesStudentRegister emmt)
        {
            enrolledCoursesStudentRegisterDapperData.Update(emmt);
        }
    }
}
