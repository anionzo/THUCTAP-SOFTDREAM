using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    internal class Subject
    {
        // Môn học
        public string IDSubject { get; set; }
        public string NameSubject { get; set; }
        public string IDDepartment { get; set; }
        public int Credits { get; set; }
        public decimal CourseworkWeight { get; set; }
        public string CourseType { get; set; }
    }
}
