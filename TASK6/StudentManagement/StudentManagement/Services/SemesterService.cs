using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentManagement.Services
{
    public class SemesterService : ISemesterService
    {
        public void Add(Semester emmt)
        {
            throw new NotImplementedException();
        }

        public void ShowList(List<Semester> list)
        {
            List<string> listNameHeader = new List<string> {
                            "ID","Tên","Năm bắt đầu", "Năm Kết thúc"
                        };
            HelperPrint.PrintTable(list, listNameHeader);
        }
    }
}
