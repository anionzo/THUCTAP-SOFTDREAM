using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class CoursesRegistered
    {
        public int IDSemester {  get; set; }
        public string NameSemester { get; set; }
        public int YearStart {  get; set; }
        public int YearEnd {  get; set; }
        public string MSSV { get; set; }
        public string NameSubject {  get; set; }
        public int Credits { get; set; }
        public decimal CourseworkWeight { get; set; }
        public string CourseType { get; set; }
    }
}
