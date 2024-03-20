using StudentManagement.App_Start;
using StudentManagement.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class EnrolledCoursesStudentRegisterController : Controller
    {

        private readonly IEnrolledCoursesStudentRegisterService _service;
        public EnrolledCoursesStudentRegisterController() {
            using (var container = BootstrapContainer.Bootstrap().Container)
            {
                _service = container.Resolve<IEnrolledCoursesStudentRegisterService>();
            }
        }

        // GET: EnrolledCoursesStudentRegister
        public ActionResult ShowSubjectFailPass(string id)
        {
            var data = _service.GetSubjectFailPassList(id);
            return PartialView(data);
        }
        public ActionResult ShowSubject() { return View(); }
    }
}