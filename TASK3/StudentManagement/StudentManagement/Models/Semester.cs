using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    internal class Semester
    {
        public string IDSemester { get; set; }
        public string NameSemester { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
    }
}
