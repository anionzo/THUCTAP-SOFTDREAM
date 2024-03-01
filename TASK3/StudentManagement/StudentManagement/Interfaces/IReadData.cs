using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interfaces
{
    internal interface IReadData<T>
    {
        T Get(object key);
        List<T> GetAll();
    }
}
