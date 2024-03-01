using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    internal class EnrolledCourses
    {
        public int IDEnrolledCourses { get; set; }
        public string IDSubject { get; set; }
        public string IDLecturer { get; set; }
        public string IDSemester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ExpectedClass {get; set;}
        public string Capacity { get; set;}
    }
}
