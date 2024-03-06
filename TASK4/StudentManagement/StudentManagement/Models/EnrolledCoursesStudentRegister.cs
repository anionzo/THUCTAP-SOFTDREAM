using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    internal class EnrolledCoursesStudentRegister
    {
        public string MSSV { get; set; }
        public int IDEnrolledCourses { get; set; }
        public decimal CourseWorkScore { get; set; }
        public decimal ExamScore { get; set; }
        public decimal TotalScore { get; set; }

    }
}
