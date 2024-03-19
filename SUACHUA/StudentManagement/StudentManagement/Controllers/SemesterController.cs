using StudentManagement.App_Start;
using StudentManagement.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class SemesterController : Controller
    {
        private readonly ISemesterService _semesterService;
        private readonly IEnrolledCoursesService _enrolledCoursesService;
        public SemesterController()
        {
            using (var container = BootstrapContainer.Bootstrap())
            {
                _semesterService = container.Container.Resolve<ISemesterService>();
                _enrolledCoursesService = container.Container.Resolve<IEnrolledCoursesService>();
            }
        }
        public ActionResult Index()
        {
            var listSemester = _semesterService.GetAll();
            return View(listSemester);
        }

        public ActionResult ListofRegisteredCoursesbySemester(int id)
        {
            var ListRegisteredCourses = _enrolledCoursesService.GetAll().Where(x => x.IDSemester == id).ToList();
            return View(ListRegisteredCourses);
        }

    }
}