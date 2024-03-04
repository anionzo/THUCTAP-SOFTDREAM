using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using StudentManagement.Data.Dapper;
using StudentManagement.Interfaces.IData;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    //internal class DependencyInstaller : IWindsorInstaller
    //{
    //    //private static string connectionString = "Data Source=.;Integrated Security=True;Trust Server Certificate=True";

    //    //public void Install(IWindsorContainer container, IConfigurationStore store)
    //    //{
    //    //    container.Register(Component.For<IStudentService>().ImplementedBy<StudentService>(),
    //    //                        Component.For<IStudentData>().ImplementedBy<StudentDapperData>().DependsOn(Dependency.OnValue("connectionString", connectionString))
    //    //                        );
    //    //    container.Register(Component.For<IStudentService>().ImplementedBy<StudentService>(),
    //    //              Component.For<IStudentData>().ImplementedBy<StudentDapperData>().DependsOn(Dependency.OnValue("connectionString", connectionString))
    //    //              );
    //    //}
    //}
}
