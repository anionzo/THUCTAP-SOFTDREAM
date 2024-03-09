using NHibernate;
using StudentManagement.Interfaces.IData;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using ISession = NHibernate.ISession;

namespace StudentManagement.Data.NHibernates
{
    public class SemesterNHibernateData : ISemesterData
    {
        public bool Create(Semester entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Semester entity)
        {
            throw new NotImplementedException();
        }

        public Semester Get(object key)
        {
            using (NHibernate.ISession session = NHibernateSession.OpenSession())
            {
                    return session.Query<Semester>().Where(b => b.IDSemester.Equals(key)).FirstOrDefault();
            }
        }

        public List<Semester> GetAll()
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                var data = session.Query<Semester>().ToList();
                return data;
            }
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Semester entity)
        {
            throw new NotImplementedException();
        }
    }
}
