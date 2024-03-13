using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Semester
    {
        [DisplayName("ID Học Kỳ")]
        public virtual int IDSemester { get; set; }
        [DisplayName("Học Kỳ")]
        public virtual string NameSemester { get; set; }
        [DisplayName("Năm bắt đầu")]
        public virtual int YearStart { get; set; }
        [DisplayName("Năm kết thúc")]
        public virtual int YearEnd { get; set; }
    }
}
