using PagedList;
using StudentManagement.App_Start;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
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
        private readonly ISemesterService _semesterService;
        public StudentController()
        {
            using (var container = BootstrapContainer.Bootstrap())
            {
                _studentService = container.Container.Resolve<IStudentService>();
                _semesterService = container.Container.Resolve<ISemesterService>();
            }
        }
        public ActionResult Index(string search, int? page)
        {
            var listStudent = _studentService.GetAll();

            ViewBag.Search = "";
            int pageNumber = (page ?? 1);
            int pageSize = 10;

            if (!string.IsNullOrEmpty(search))
            {
                var onePageOfStudent = listStudent.Where(x => x.MSSV.ToLower().Contains(search.ToLower())).ToPagedList(pageNumber, pageSize);
                ViewBag.Students = onePageOfStudent;
                ViewBag.Search = search;
            }
            else
            {
                var onePageOfStudent = listStudent.ToPagedList(pageNumber, pageSize);
                ViewBag.Students = onePageOfStudent;
            }
            return View();
        }
        public ActionResult Details(object id)
        {
            Student student = _studentService.Get(id);
            ViewBag.Student = student;
            return View(student);
        }
        public ActionResult ShowListSubjectRegister(object id)
        {
           

            var listSemester = _semesterService.GetAll();
            List<CoursesRegistered> list = new List<CoursesRegistered>();

            foreach (var item in listSemester)
            {
                var count = _studentService.GetNumberSubjectRegister(item.IDSemester.ToString(), id.ToString());
                if (count > 0)
                {
                    List<CoursesRegistered> itemCoursesRegistered = _studentService.GetAllCoursesRegistered(item.IDSemester.ToString(), id.ToString());
                    list.AddRange(itemCoursesRegistered);
             
                }
            }
            ViewBag.Count = list.Count;
            if(list.Count > 0)
            {
                Student student = _studentService.Get(list[0].MSSV);
                ViewBag.Student = student;
            }
            return View(list);
        }
    }
}