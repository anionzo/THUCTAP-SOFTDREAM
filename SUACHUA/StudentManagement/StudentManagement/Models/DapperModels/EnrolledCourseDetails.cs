using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManagement.Models.DapperModels
{
    public class EnrolledCourseDetails
    {
        public int IDEnrolledCourses { get; set; }

        public string NameDepartment { get; set; }
        public string IDLecturer { get; set; }
        public string NameLecturer { get; set; }
        public string NameSubject { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]

        public DateTime EndDate { get; set; }
        public string ExpectedClass { get; set; }
        public int Credits { get; set; }
        public string CourseType { get; set; }
    }
}