using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class Semester
    {
        public  int IDSemester { get; set; }
        public  string NameSemester { get; set; }
        public  int YearStart { get; set; }
        public  int YearEnd { get; set; }
    }
}
