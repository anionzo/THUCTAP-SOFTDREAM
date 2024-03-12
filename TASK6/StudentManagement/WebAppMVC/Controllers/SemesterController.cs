using StudentManagement.CastleWinsdor;
using StudentManagement.Interfaces.IData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMVC.Controllers
{
    public class SemesterController : Controller
    {
        ContainerBootstrapper container;
        // GET: Semester
        public SemesterController() {
            container = ContainerBootstrapper.Bootstrap();
        }
        public ActionResult Index()
        {
           var listSemester = container.SemesterData.GetAll();
            return View(listSemester);
        }

        public ActionResult ListofRegisteredCoursesbySemester(int id)
        {
            var ListRegisteredCourses = container.EnrolledCoursesData.GetAll().Where(x => x.IDSemester == id).ToList();
            return View(ListRegisteredCourses);
        }


    }
}
