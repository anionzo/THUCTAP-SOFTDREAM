using StudentManagement.App_Start;
using StudentManagement.Data;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagement.Controllers
{
    public class EnrolledCoursesStudentRegisterController : Controller
    {

        private readonly IEnrolledCoursesStudentRegisterService _service;
        public EnrolledCoursesStudentRegisterController()
        {
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
        public ActionResult ShowSubjectBySemester()
        {

            var data = _service.GetAllCoursesRegistered();
            return View(data);

        }
        public ActionResult GetALLEnrolledCoursesStudentRegister(int id)
        {
            var data = _service.GetAll(id);
            return PartialView(data);
        }
        public ActionResult EditScore(int id, string mssv)
        {
            var data = _service.GetAll(id).Where(x => x.MSSV.Equals(mssv)).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult EditScore(EnrolledCoursesStudentRegister emty)
        {
            try
            {
                _service.Update(emty);
                return RedirectToAction("GetEnrolledCourseDetails", "EnrolledCourses", new { id = emty.IDEnrolledCourses });

            }
            catch (Exception ex)
            {
                return View(emty);
            }
        }
    }
}