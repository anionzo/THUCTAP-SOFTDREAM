using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Student
    {
        public virtual string MSSV { get; set; }
        public virtual string NameStudenr { get; set; }
        public virtual DateTime DayAdmission { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string Gender { get; set; }
        public virtual string Education { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual string CCCD { get; set; }
        public virtual string IDDiscipline { get; set; }
        public virtual string Ethnicity { get; set; }
        public virtual string Religion { get; set; }
        public virtual string PermanentAddress { get; set; }
        public virtual string ImageAvatar { get; set; }
        public virtual string Status { get; set; }

        //public string GetDayAdmissionFormat(string format)
        //{
        //    return DayAdmission.ToString(format);
        //}

        //public string GetDateOfBirthFormat(string format)
        //{
        //    return DateOfBirth.ToString(format);
        //}
    }
}
