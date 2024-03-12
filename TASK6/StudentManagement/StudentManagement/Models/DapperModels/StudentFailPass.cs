using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models.DapperModels
{
    public class StudentFailPass
    {
        public virtual string MSSV { get; set; }
        public virtual int IDEnrolledCourses { get; set; }
        public virtual decimal CourseWorkScore { get; set; }
        public virtual decimal ExamScore { get; set; }
        public virtual decimal TotalScore { get; set; }
        public virtual string Result { get; set; }

    }
}
