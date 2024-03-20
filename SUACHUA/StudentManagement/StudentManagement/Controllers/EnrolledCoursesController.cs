using StudentManagement.App_Start;
using StudentManagement.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.WebPages;

namespace StudentManagement.Controllers
{
    public class EnrolledCoursesController : Controller
    {
        private readonly IEnrolledCoursesService _enrolledCoursesService;
        public EnrolledCoursesController()
        {
            using(var container = BootstrapContainer.Bootstrap().Container)
            {
                _enrolledCoursesService = container.Resolve<IEnrolledCoursesService>();
            }
        }

        // GET: EnrolledCourses
        public ActionResult Index()
        {
            var data = _enrolledCoursesService.GetAll();
            return View(data);
        }
        public ActionResult ShowSubjectBySemester()
        {

            var data = _enrolledCoursesService.GetAllCoursesRegistered();
            return View(data);

        }
        public ActionResult GetEnrolledCourseDetails(int id)
        {
            var data = _enrolledCoursesService.GetEnrolledCourseDetails(id);
            return View(data);
        }
    }
}