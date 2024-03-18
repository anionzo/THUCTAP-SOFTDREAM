using StudentManagement.Interfaces.IData;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
using StudentManagement.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentManagement.Services
{
    public class SemesterService : ISemesterService
    {
        private readonly ISemesterData _semesterData;
        public SemesterService(ISemesterData semesterData)
        {
            _semesterData = semesterData;
        }

        public void Add(Semester emmt)
        {
            throw new NotImplementedException();
        }

        public List<Semester> GetAll()
        {
             return _semesterData.GetAll();
        }
    }
}
