using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    internal class Subject
    {
        // Môn học
        public virtual string IDSubject { get; set; }
        public virtual string NameSubject { get; set; }
        public virtual string IDDepartment { get; set; }
        public virtual int Credits { get; set; }
        public virtual decimal CourseworkWeight { get; set; }
        public virtual string CourseType { get; set; }
    }
}
