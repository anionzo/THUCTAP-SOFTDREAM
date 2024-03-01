using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Models
{
    internal class Lecturers
    {
        // giảng viên
        public string IDLecturer { get; set; }
        public string NameLecturer { get; set; }
        public DateTime DayAdmission { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Education { get; set; }
        public string PhoneNumber { get; set; }
        public string CCCD { get; set; }
        public string IDDiscipline { get; set; }
        public string Ethnicity { get; set; }
        public string Religion { get; set; }       
        public string PermanentAddress { get; set; }
        public string ImageAvatar { get; set; }
        public string Status { get; set; }
    }
}
