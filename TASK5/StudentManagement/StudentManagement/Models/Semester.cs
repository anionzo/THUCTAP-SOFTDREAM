using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Semester
    {
        public virtual string IDSemester { get; set; }
        public virtual string NameSemester { get; set; }
        public virtual int YearStart { get; set; }
        public virtual int YearEnd { get; set; }
    }
}
