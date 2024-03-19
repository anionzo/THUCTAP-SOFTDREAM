using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentManagement.Models.DapperModels
{
    public class SubjectFailPass
    {
        public string STT { get; set; }
        [DisplayName("Mã Môn")]
        public int IDEnrolledCourses { get; set; }
        [DisplayName("Tên Môn")]
        public string NameSubject { get; set; }
        [DisplayName("Số TC")]
        public int Credits { get; set; }
        [DisplayName("Loại")]
        public string CourseType { get; set; }
        [DisplayName("Điểm Quá Trình")]
        public decimal CourseWorkScore { get; set; }
        [DisplayName("Điểm Thi")]
        public decimal ExamScore { get; set; }
        [DisplayName("Điểm Tổng")]
        public decimal TotalScore { get; set; }
        [DisplayName("Kết Quả")]
        public string Result { get; set; }
    }
}