using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class CoursesRegistered
    {
        [DisplayName("Mã Học Kỳ")]
        public int IDSemester { get; set; }
        [DisplayName("Học Kỳ")]
        public string NameSemester { get; set; }
        [DisplayName("Năm bắt đầu")]
        public virtual int YearStart { get; set; }
        [DisplayName("Năm kết thúc")]
        public virtual int YearEnd { get; set; }
        [DisplayName("Tên Môn Học")]
        public string NameSubject { get; set; }
        [DisplayName("Tín Chỉ")]
        public int Credits { get; set; }
        [DisplayName("Tỉ Lệ QT")]
        public decimal CourseworkWeight { get; set; }
        [DisplayName("Loại Môn")]
        public string CourseType { get; set; }
        [DisplayName("Mã SV")]
        public string MSSV { get; set; }
        [DisplayName("ID Môn DK")]
        public int IDEnrolledCourses { get; set; }
        [DisplayName("Điểm QT")]
        public decimal CourseWorkScore { get; set; }
        [DisplayName("Điểm Thi")]
        public decimal ExamScore { get; set; }
        [DisplayName("Điểm Tổng")]
        public decimal TotalScore { get; set; }
    }
}
