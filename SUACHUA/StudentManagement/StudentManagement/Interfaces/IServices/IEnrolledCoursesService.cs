using StudentManagement.Models;
using StudentManagement.Models.DapperModels;
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
        List<CoursesRegistered> GetAllCoursesRegistered();
        EnrolledCourseDetails GetEnrolledCourseDetails(int EnrolledCourseID);

    }
}
