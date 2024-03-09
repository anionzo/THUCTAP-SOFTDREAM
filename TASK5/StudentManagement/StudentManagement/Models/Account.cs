using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Account
    {
        public virtual int IDAccount { get; set; }
        public virtual string UserName { get; set; }
        public virtual string Password { get; set; }

        public virtual int GetIDAccount()
        {
            return IDAccount;
        }

        // Phương thức setter cho IDAccount (nếu cần)
        public virtual void SetIDAccount(int id)
        {
            IDAccount = id;
        }
    }

}
