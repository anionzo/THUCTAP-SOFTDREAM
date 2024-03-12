using Microsoft.Ajax.Utilities;
using StudentManagement.CastleWinsdor;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppMVC.Controllers
{
    public class StudentController : Controller
    {
        ContainerBootstrapper contaner;

        public StudentController()
        {
            contaner = ContainerBootstrapper.Bootstrap();

        }

        // GET: Student
        public ActionResult Index()
        {
            ViewBag.Title = "Student";
            return View();
        }
        
        public ActionResult ShowList() {
            List<Student> listData = contaner.StudentData.GetAll();
            return View(listData);
        }

        public ActionResult Details(object  id)
        {
            Student student = contaner.StudentData.Get(id);
            ViewBag.Student = student;
            return View(student);
        }
        public ActionResult ShowListSubjectRegister(object id)
        {
            var listSemester = contaner.SemesterData.GetAll();
            List<CoursesRegistered> list = new List<CoursesRegistered>();

            foreach (var item in listSemester)
            {
                var count = contaner.StudentData.GetNumberSubjectRegister(item.IDSemester.ToString(), id.ToString());
                if (count > 0)
                {
                    List<CoursesRegistered> itemCoursesRegistered = contaner.StudentData.GetAllCoursesRegistered(item.IDSemester.ToString(), id.ToString());
                    list.AddRange(itemCoursesRegistered); 
                }
            }
            return View(list); 
        }

    }
}