using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    internal class Department
    {
        // khoa
        public virtual string IDDepartment { get; set; }
        public virtual string NameDepartment { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string IDUniversity { get; set; }
        public virtual string Email { get; set; }
    }
}
