using NHibernate;
using NHibernate.Cfg;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StudentManagement.Data
{
    public class NHibernateSession
    {
        private static readonly object sessionFactoryLock = new object();
        private static ISessionFactory _sessionFactory;

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    lock (sessionFactoryLock)
                    {


                        if (_sessionFactory == null)
                        {
                            var configuration = new NHibernate.Cfg.Configuration();

                            var configurationPath = @"..\..\hibernate.cfg.xml";
                            configuration.Configure(configurationPath);

                            var departmentCfgFile = (@"..\..\Models\Mappings\Department.hbm.xml");
                            configuration.AddFile(departmentCfgFile);

                            var disciplineCfgFile = (@"..\..\Models\Mappings\Discipline.hbm.xml");
                            configuration.AddFile(disciplineCfgFile);

                            var enrolledCoursesCfgFile = (@"..\..\Models\Mappings\EnrolledCourses.hbm.xml");
                            configuration.AddFile(enrolledCoursesCfgFile);

                            var enrolledCoursesStudentRegisterCfgFile = (@"..\..\Models\Mappings\EnrolledCoursesStudentRegister.hbm.xml");
                            configuration.AddFile(enrolledCoursesStudentRegisterCfgFile);

                            //var lecturerCfgFile = @"..\..\Models\Mappings\Lecturer.hbm.xml";
                            //configuration.AddFile(lecturerCfgFile);

                            var semesterCfgFile = (@"..\..\Models\Mappings\Semester.hbm.xml");
                            configuration.AddFile(semesterCfgFile);

                            var studentCfgFile = @"..\..\Models\Mappings\Student.hbm.xml";
                            configuration.AddFile(studentCfgFile);

                            //var subjectCfgFile = (@"..\..\Models\Mappings\Subject.hbm.xml");
                            //configuration.AddFile(subjectCfgFile);

                            var universityCfgFile = (@"..\..\Models\Mappings\University.hbm.xml");
                            configuration.AddFile(universityCfgFile);

                            //var accountCfgFile = (@"..\..\Models\Mappings\Account.hbm.xml");
                            //configuration.AddFile(accountCfgFile);

                            _sessionFactory = configuration.BuildSessionFactory();
                        }
                    }
                }
                return _sessionFactory;
            }
        }

    }
}
