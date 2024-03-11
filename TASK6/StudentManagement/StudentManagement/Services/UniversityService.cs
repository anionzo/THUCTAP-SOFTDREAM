using StudentManagement.Interfaces.IData;
using StudentManagement.Interfaces.IServices;
using StudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Services
{
    public class UniversityService : IUniversityService
    {
        private readonly IUniversityData _universityData;
        public UniversityService(IUniversityData universityData) {
            _universityData = universityData;
        }
        public void Add(University emmt)
        {
            _universityData.Create(emmt);
        }

        public void ShowList(List<University> list)
        {
            list = _universityData.GetAll();
            
        }
    }
}
