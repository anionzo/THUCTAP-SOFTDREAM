using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Models.DapperModels
{
    public class EnrolledCourseDetails
    {
        public string DepartmentName { get; set; }
        public int LecturerID { get; set; }
        public string LecturerName { get; set; }
        public string SubjectName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ExpectedClass { get; set; }
        public int Credits { get; set; }
        public string CourseType { get; set; }
    }
}