using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    internal class EnrolledCourses
    {
        public virtual int IDEnrolledCourses { get; set; }
        public virtual string IDSubject { get; set; }
        public virtual string IDLecturer { get; set; }
        public virtual string IDSemester { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual string ExpectedClass { get; set; }
        public virtual string Capacity { get; set; }
    }
}
