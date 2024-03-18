using StudentManagement.App_Start;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController()
        {
           using(var container = BootstrapContainer.Bootstrap()) {
            _studentService  = container.Container.Resolve<IStudentService>();
           }
        }
        public ActionResult Index()
        {
            var listStudent = _studentService.GetAll();
            return View(listStudent);
        }
    }
}