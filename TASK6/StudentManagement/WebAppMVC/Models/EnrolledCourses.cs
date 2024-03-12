using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class EnrolledCourses
    {
        public virtual int IDEnrolledCourses { get; set; }
        public virtual string IDSubject { get; set; }
        public virtual string IDLecturer { get; set; }
        public virtual int IDSemester { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string ExpectedClass { get; set; }
        public virtual int Capacity { get; set; }
    }
}
