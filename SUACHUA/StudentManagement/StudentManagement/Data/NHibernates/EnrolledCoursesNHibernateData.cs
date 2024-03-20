using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using StudentManagement.Models.DapperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data.NHibernates
{
    public class EnrolledCoursesNHibernateData : IEnrolledCoursesData
    {
        public bool Create(EnrolledCourses entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(EnrolledCourses entity)
        {
            throw new NotImplementedException();
        }

        public EnrolledCourses Get(object key)
        {
            using (NHibernate.ISession session = NHibernateSession.OpenSession())
            {
                return session.Query<EnrolledCourses>().Where(x => x.IDEnrolledCourses.Equals(key)).FirstOrDefault();
            }
        }

        public List<EnrolledCourses> GetAll()
        {
            using (NHibernate.ISession session = NHibernateSession.OpenSession())
            {
                return session.Query<EnrolledCourses>().ToList();
            }
        }

        public List<CoursesRegistered> GetAllCoursesRegistered()
        {
            throw new NotImplementedException();
        }

        public EnrolledCourseDetails GetEnrolledCourseDetails(int EnrolledCourseID)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(EnrolledCourses entity)
        {
            throw new NotImplementedException();
        }
    }
}
