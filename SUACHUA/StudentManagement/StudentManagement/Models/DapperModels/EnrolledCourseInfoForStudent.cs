using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.DapperModels
{
    public class EnrolledCourseInfoForStudent 
    {
        public string MSSV { get; set; }
        public decimal IDEnrolledCourses { get; set; }
        public decimal CourseWorkScore { get; set; }
        public decimal ExamScore { get; set; }
        public decimal TotalScore { get; set; }
        public string NameSemester { get; set; }
        public string CourseworkWeight { get; set; }
        public string NameSubject { get; set; }



    }
}
