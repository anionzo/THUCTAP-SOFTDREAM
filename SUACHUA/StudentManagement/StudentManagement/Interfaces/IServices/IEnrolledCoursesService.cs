using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interfaces.IServices
{
    public interface IEnrolledCoursesService : IReadWrite<EnrolledCourses>
    {
        List<EnrolledCourses> GetAll(); 
    }
}
