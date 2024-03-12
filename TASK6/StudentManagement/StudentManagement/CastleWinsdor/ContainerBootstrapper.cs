using Castle.Windsor;
using Castle.Windsor.Installer;
using StudentManagement.Interfaces.IData;
using StudentManagement.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.CastleWinsdor
{
    public class ContainerBootstrapper : IContainerAccessor, IDisposable
    {
        readonly IWindsorContainer _container;

        IStudentService _studentService;
        ISemesterService _semesterService;
        IEnrolledCoursesService _enrolledCoursesService;
        IEnrolledCoursesStudentRegisterService _enrolledCoursesStudentRegisterService;

        IStudentData _studentData;
        ISemesterData _semesterData;
        IEnrolledCoursesData _enrolledCoursesData;
        IEnrolledCoursesStudentRegisterData _enrolledCoursesStudentRegisterData;


        ContainerBootstrapper(IWindsorContainer container)
        {
            this._container = container;
            //------------- Service
            this._studentService = _container.Resolve<IStudentService>();
            this._semesterService = _container.Resolve<ISemesterService>();
            this._enrolledCoursesService = _container.Resolve<IEnrolledCoursesService>();
            this._enrolledCoursesStudentRegisterService = _container.Resolve<IEnrolledCoursesStudentRegisterService>();
            //------------- Data
            this._studentData = _container.Resolve<IStudentData>();
            this._semesterData = _container.Resolve<ISemesterData>();
            this._enrolledCoursesData = _container.Resolve<IEnrolledCoursesData>();
            this._enrolledCoursesStudentRegisterData = _container.Resolve<IEnrolledCoursesStudentRegisterData>();
        }
        public IWindsorContainer Container
        {
            get { return _container; }
        }

        public IStudentService StudentService { get => _studentService; }
        public ISemesterService SemesterService { get => _semesterService;  }
        public IEnrolledCoursesService EnrolledCoursesService { get => _enrolledCoursesService; }
        public IEnrolledCoursesStudentRegisterService EnrolledCoursesStudentRegisterService { get => _enrolledCoursesStudentRegisterService; }
        public IStudentData StudentData { get => _studentData; }
        public ISemesterData SemesterData { get => _semesterData; }
        public IEnrolledCoursesData EnrolledCoursesData { get => _enrolledCoursesData;   }
        public IEnrolledCoursesStudentRegisterData EnrolledCoursesStudentRegisterData { get => _enrolledCoursesStudentRegisterData; }
        public static ContainerBootstrapper Bootstrap()
        {
            var container = new WindsorContainer().
                Install(FromAssembly.This());
            return new ContainerBootstrapper(container);
        }

        public void Dispose()
        {
            Container.Dispose();
        }

        
    }
}
