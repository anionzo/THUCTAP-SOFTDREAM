using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class EnrolledCoursesStudentRegister
    {
        [DisplayName("Mã số")]
        public virtual string MSSV { get; set; }
        [DisplayName("Mã Môn Đăng Ký")]
        public virtual int IDEnrolledCourses { get; set; }
        [DisplayName("Điểm quá trình")]
        public virtual decimal CourseWorkScore { get; set; }
        [DisplayName("Điểm thi")]
        public virtual decimal ExamScore { get; set; }
        [DisplayName("Điểm tổng")]
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
