using StudentManagement.Interfaces.IData;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectData _subjectData;
        public SubjectService(ISubjectData subjectData)
        {
            _subjectData = subjectData;
        }
        public void Add(Subject emmt)
        {
            throw new NotImplementedException();
        }

        public List<Subject> GetAll()
        {
           return _subjectData.GetAll();
        }
    }
}
