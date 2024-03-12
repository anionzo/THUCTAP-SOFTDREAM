using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using StudentManagement.Data.Dapper;
using StudentManagement.Data.NHibernates;
using StudentManagement.Interfaces.IData;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.CastleWinsdor
{
    public class DependencyInstaller : IWindsorInstaller
    {
        string connectionString = "Data Source=.;Initial Catalog=QUANLY_SINHVIEN;Integrated Security=True";


        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //////// 7dataa
            container.Register(Component.For<IStudentService>().ImplementedBy<StudentService>(),
                Component.For<IStudentData>().ImplementedBy<StudentDapperData>().DependsOn(Dependency.OnValue("connectionString", connectionString))
            );
            container.Register(Component.For<ISemesterService>().ImplementedBy<SemesterService>(),
                Component.For<ISemesterData>().ImplementedBy<SemesterDapperData>().DependsOn(Dependency.OnValue("connectionString", connectionString))
            );
            container.Register(Component.For<IEnrolledCoursesService>().ImplementedBy<EnrolledCoursesService>(),
                Component.For<IEnrolledCoursesData>().ImplementedBy<EnrolledCoursesDapperData>().DependsOn(Dependency.OnValue("connectionString", connectionString))
            );
            container.Register(Component.For<IEnrolledCoursesStudentRegisterService>().ImplementedBy<EnrolledCoursesStudentRegisterService>(),
                Component.For<IEnrolledCoursesStudentRegisterData>().ImplementedBy<EnrolledCoursesStudentRegisterDapperData>().DependsOn(Dependency.OnValue("connectionString", connectionString))
            );
            //=-=====
            container.Register(Component.For<ISubjectService>().ImplementedBy<SubjectService>(),
                Component.For<ISubjectData>().ImplementedBy<SubjectDapperData>().DependsOn(Dependency.OnValue("connectionString", connectionString))
            );
            container.Register(Component.For<IAccountService>().ImplementedBy<AccountService>(),
                Component.For<IAccountData>().ImplementedBy<AccountDapperData>().DependsOn(Dependency.OnValue("connectionString", connectionString))
            );
            container.Register(Component.For<IDepartmentService>().ImplementedBy<DepartmentService>(),
                Component.For<IDepartmentData>().ImplementedBy<DepartmentDapperData>().DependsOn(Dependency.OnValue("connectionString", connectionString))
            );
            container.Register(Component.For<IDisciplineService>().ImplementedBy<DisciplineService>(),
                Component.For<IDisciplineData>().ImplementedBy<DisciplineDapperData>().DependsOn(Dependency.OnValue("connectionString", connectionString))
            );
            container.Register(Component.For<ILecturersService>().ImplementedBy<LecturersService>(),
                Component.For<ILecturersData>().ImplementedBy<LecturersDapperData>().DependsOn(Dependency.OnValue("connectionString", connectionString))
            );
            container.Register(Component.For<IUniversityService>().ImplementedBy<UniversityService>(),
                Component.For<IUniversityData>().ImplementedBy<UniversityDapperData>().DependsOn(Dependency.OnValue("connectionString", connectionString))
            );

            ///// Nhibernate
            //container.Register(Component.For<IStudentService>().ImplementedBy<StudentService>(),
            //  Component.For<IStudentData>().ImplementedBy<StudentNHibernateData>()
            //);
            //container.Register(Component.For<ISemesterService>().ImplementedBy<SemesterService>(),
            //    Component.For<ISemesterData>().ImplementedBy<SemesterNHibernateData>()
            //);
            //container.Register(Component.For<IEnrolledCoursesService>().ImplementedBy<EnrolledCoursesService>(),
            //    Component.For<IEnrolledCoursesData>().ImplementedBy<EnrolledCoursesNHibernateData>()
            //);
            //container.Register(Component.For<IEnrolledCoursesStudentRegisterService>().ImplementedBy<EnrolledCoursesStudentRegisterService>(),
            //Component.For<IEnrolledCoursesStudentRegisterData>().ImplementedBy<EnrolledCoursesStudentRegisterNHibernateData>()
            //);

        }
    }
}
