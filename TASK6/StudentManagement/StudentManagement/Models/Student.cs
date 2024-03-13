using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    public class Student
    {
        [DisplayName("Mã SV")]
        public virtual string MSSV { get; set; }
        [DisplayName("Tên")]
        public virtual string NameStudenr { get; set; }
        [DisplayName("Day Admission")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime DayAdmission { get; set; }
        [DisplayName("Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public virtual DateTime DateOfBirth { get; set; }
        [DisplayName("Giới Tính")]
        public virtual string Gender { get; set; }
        public virtual string Education { get; set; }
        [DisplayName("SĐT")]
        public virtual string PhoneNumber { get; set; }
        public virtual string CCCD { get; set; }
        public virtual string IDDiscipline { get; set; }
        [DisplayName("Dân Tộc")]
        public virtual string Ethnicity { get; set; }
        [DisplayName("Tôn Giáo")]
        public virtual string Religion { get; set; }
        [DisplayName("Địa chỉ hiện tại")]
        public virtual string PermanentAddress { get; set; }
        public virtual string ImageAvatar { get; set; }
        [DisplayName("Trạng Thái")]
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
