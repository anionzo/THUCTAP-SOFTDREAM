using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppMVC.Models
{
    public class Semester
    {
        public virtual int IDSemester { get; set; }
        public virtual string NameSemester { get; set; }
        public virtual int YearStart { get; set; }
        public virtual int YearEnd { get; set; }
    }
}
