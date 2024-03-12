using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class EnrolledCoursesStudentRegister
    {
        public virtual string MSSV { get; set; }
        public virtual int IDEnrolledCourses { get; set; }
        public virtual decimal CourseWorkScore { get; set; }
        public virtual decimal ExamScore { get; set; }
        public virtual decimal TotalScore { get; set; }
        // Ghi đè phương thức Equals()
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            var other = (EnrolledCoursesStudentRegister)obj;
            return MSSV == other.MSSV && IDEnrolledCourses == other.IDEnrolledCourses;
        }

       // Ghi đè phương thức GetHashCode()
        public override int GetHashCode()
        {
            return HashCode.Combine(MSSV, IDEnrolledCourses);
        }
    }
}
