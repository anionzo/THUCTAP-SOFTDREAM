using StudentManagement.CastleWinsdor;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMVC.Controllers
{
    public class EnrolledCoursesStudentRegisterController : Controller
    {
        // GET: EnrolledCoursesStudentRegister
        ContainerBootstrapper container;
        public EnrolledCoursesStudentRegisterController()
        {
            container = ContainerBootstrapper.Bootstrap();
        }
        public ActionResult listCoursesStudentRegister(int id )
        {
            var data = container.EnrolledCoursesStudentRegisterData.GetAll().Where(X => X.IDEnrolledCourses == id).ToList();
            return View(data);
        }
        public ActionResult ListStudent_Fail_Pass(int id)
        {
            var data = container.EnrolledCoursesStudentRegisterData.GetStudent_Fail_PassList(id);
            return View(data);
        }

        public ActionResult Edit(int id,string mssv)
        {
            var data = container.EnrolledCoursesStudentRegisterData.GetAll().Where(x => x.IDEnrolledCourses == id && x.MSSV.Equals(mssv)).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(EnrolledCoursesStudentRegister emty)
        {
            bool resut =  container.EnrolledCoursesStudentRegisterData.Update(emty);
            if(resut == true)
            {
                return RedirectToAction("listCoursesStudentRegister", "EnrolledCoursesStudentRegister", new { id = emty.IDEnrolledCourses });
            }
            else
            {
                return View(emty);
            }
        }
    }
}