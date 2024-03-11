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
    public class SubjectService : ISubjectService
    {
        public void Add(Subject emmt)
        {
            throw new NotImplementedException();
        }

        public void ShowList(List<Subject> list)
        {
            List<string> listNameHeader = new List<string> {
                            "ID","Số TC", "Tỷ Lệ","Loại khóa học","Tên Môn Học"
                        };
            HelperPrint.PrintTable(list, listNameHeader);
        }
       
    }
}
