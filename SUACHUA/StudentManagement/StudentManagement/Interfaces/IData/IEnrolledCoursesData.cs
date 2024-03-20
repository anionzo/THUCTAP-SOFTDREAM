using StudentManagement.Models;
using StudentManagement.Models.DapperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interfaces.IData
{
    public interface IEnrolledCoursesData: IReadData<EnrolledCourses>, ICUDData<EnrolledCourses>
    {
        List<CoursesRegistered> GetAllCoursesRegistered();
        EnrolledCourseDetails GetEnrolledCourseDetails(int EnrolledCourseID);
    }
}
