using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    internal class Discipline
    {
        // bộ môn
        public virtual string IDDiscipline { get; set; }
        public virtual string NameDiscipline { get; set; }
        public virtual string IDDepartment { get; set; }
    }
}
