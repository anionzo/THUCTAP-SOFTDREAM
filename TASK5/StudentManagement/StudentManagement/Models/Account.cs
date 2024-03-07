using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    internal class Account
    {
        public virtual int IDAcount { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }
    }
}
