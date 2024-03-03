using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interfaces
{
    internal interface IReadWrite<T>
    {
        void Add(T emmt);
        void ShowList(List<T> list);

    }
}
