using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    internal class EnrolledCoursesService : IEnrolledCoursesService
    {
        public void Add(EnrolledCourses emmt)
        {
            throw new NotImplementedException();
        }

        public void ShowList(List<EnrolledCourses> list)
        {
            List<string> listNameHeader = new List<string> {
                            "ID","ID Subject","IDLecture","ID HK", "NgàyBD","Ngày KT","Lớp","Sĩ SỐ"
                        };
            HelperPrint.PrintTable(list, listNameHeader);
        }
    }
}
