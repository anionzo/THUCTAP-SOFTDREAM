using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Interfaces
{
    public interface ICUDData<T>
    {
        bool Create(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        bool Save();
    }
}
