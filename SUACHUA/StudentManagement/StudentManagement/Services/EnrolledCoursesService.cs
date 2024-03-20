using StudentManagement.Data.Dapper;
using StudentManagement.Interfaces.IData;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
using StudentManagement.Models.DapperModels;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    public class EnrolledCoursesService : IEnrolledCoursesService
    {
        private readonly IEnrolledCoursesData _coursesData;
        public EnrolledCoursesService(IEnrolledCoursesData coursesData)
        {
            _coursesData = coursesData;
        }

        public void Add(EnrolledCourses emmt)
        {
            throw new NotImplementedException();
        }

        public List<EnrolledCourses> GetAll()
        {
            return _coursesData.GetAll();
        }
        public List<CoursesRegistered> GetAllCoursesRegistered()
        {
            return _coursesData.GetAllCoursesRegistered();
        }

        public EnrolledCourseDetails GetEnrolledCourseDetails(int EnrolledCourseID)
        {
            return _coursesData.GetEnrolledCourseDetails(EnrolledCourseID);
        }
    }
}
